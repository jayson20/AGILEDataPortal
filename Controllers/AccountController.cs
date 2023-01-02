using AGILEDataPortal.Data;
using AGILEDataPortal.HelperClasses;
using AGILEDataPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AGILEDataPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly IMailHelper _mailHelper;

        public AccountController(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IWebHostEnvironment env,
          IMailHelper mailHelper


        /* IConfiguration config*/)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _mailHelper = mailHelper;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { 
                        UserName = model.Email, 
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };
                        var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        {
                            return RedirectToAction("UserManagement", "Admin");
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return View(model);
        }

        //Remote validation
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //[AllowAnonymous]
        //// [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginDto login, string returnUrl = null)
        //{
        //    var userList = await _userManager.Users.ToListAsync();

        //    try
        //    {
        //        ViewData["ReturnUrl"] = returnUrl;
        //        if (ModelState.IsValid)
        //        {
        //            

        //            

        //            if (loginUser?.IsEnabled == false)
        //            {
        //                _signInManager.SignOutAsync().GetAwaiter().GetResult();
        //                ModelState.AddModelError(string.Empty,
        //                    "Your Account has been disabled. Please refer to the Administrator.");
        //                return View(login);
        //            }

        //            // This doesn't count login failures towards account lockout
        //            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //            var claimResult = AddUserToClaims(loginUser);
        //            if (claimResult == false)
        //            {
        //                ModelState.AddModelError(string.Empty, "Internal Server Error. Could not login");
        //                return View(login);
        //            }

        //            var l = loginUser;

        //            var result = await _signInManager
        //                .PasswordSignInAsync(login.Email, login.Password, true, lockoutOnFailure: false);
        //            if (result.Succeeded)
        //            {

        //                var user = await _userManager.FindByNameAsync(login.Email);
        //                var roles = await _userManager.GetRolesAsync(user);


        //                if (loginUser.IsSuperUser)
        //                    return RedirectToAction("Index", "UserManagement");

        //                if (roles.Contains("Team Member"))
        //                {
        //                    return RedirectToAction("Index", "Approval");
        //                }

        //                if (returnUrl != null)
        //                    return RedirectToLocal(returnUrl);
        //                else

        //                    return RedirectToAction("Dashboard", "Approval");
        //            }
        //            else
        //            {
        //                RemoveUserToClaims(loginUser);
        //                ModelState.AddModelError(string.Empty, "User Name or PassWord not Correct");
        //            }

        //            if (result.IsLockedOut)
        //            {
        //                return RedirectToAction(nameof(Lockout));
        //            }
        //            else
        //            {
        //                return View(login);
        //            }

        //        }


        //        // If we got this far, something failed, redisplay form
        //        return View(login);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? "Network Error, Please try again later.");
        //        return View(login);
        //    }
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginUser = _userManager.Users
                        .FirstOrDefaultAsync(e => e.Email == model.Email)
                        .GetAwaiter()
                        .GetResult();
                    if (loginUser == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                        return View();
                    }
                    if (!loginUser.IsPassWordChanged)
                    {
                        var _result = _signInManager.CheckPasswordSignInAsync(loginUser, model.Password, false).GetAwaiter().GetResult();

                        if (_result.Succeeded)
                        {
                            TempData["Id"] = loginUser.Id;

                            return RedirectToAction("ChangePassword", new { id = loginUser.Id });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                            return View("Login");
                        }

                    }

                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        //Handles redirect after login
                        //Prevent open redirect attack
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("SchoolByLGA", "GeoLocationInsights");
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Invalid username or password");

                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return View(model);
        }

        #region ChangePassword
        [AllowAnonymous]
        public IActionResult ChangePassword(string id)
        {

            try
            {
                //var n = TempData["Id"];
                //TempData["Id"] != null
                if (id != null && id != "")
                {
                    ViewBag.Id = id;
                    return View();
                }

                return RedirectToAction("Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Login");
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel newPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginUser = await _userManager.FindByIdAsync(newPassword.Id);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(loginUser);
                    var result = await _userManager.ResetPasswordAsync(loginUser, token, newPassword.Password);


                    if (result.Succeeded)
                    {
                        loginUser.IsPassWordChanged = true;
                        //loginUser.IsEnabled = true;
                        await _userManager.UpdateAsync(loginUser);
                        TempData["type"] = "Success";
                        TempData["message"] = "Password changed successfully, Login to continue !";
                        return RedirectToAction("Login", "Account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }

                    return View();
                }
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? "Network Error, Please try again later.");
                return View(newPassword);
            }


        }
        #endregion


        #region Forgot Password

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                        new { Email = model.Email, token = token }, Request.Scheme);


                    #region Send Password Reset link Mail
                    var path = _env.WebRootPath;
                    string body = string.Empty;
                    using (StreamReader reader = new StreamReader(Path.Combine(path, "mailTemplate\\PasswordResetLink.html")))
                    {
                        //var callbackUrl = Url.ChangePassWordLink(Request.Scheme);


                        body = reader.ReadToEnd();
                        body = body.Replace("{resetLink}", HtmlEncoder.Default.Encode(passwordResetLink));
                        //body = body.Replace("{resetLink}", passwordResetLink);
                        body = body.Replace("{user}", user.FirstName);

                    }

                    await _mailHelper.sendMailAsync(model.Email, "Password Reset Link", body);
                    #endregion



                    return View("ForgotPasswordConfirmation");

                }

                return View("ForgotPasswordEmailError");

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                // Don't reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }

        #endregion

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
