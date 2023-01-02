using AGILEDataPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AGILEDataPortal.Controllers
{
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles = "User")] -- 
    //[Authorize(Roles = "Admin")] -- AND
    //[Authorize(Roles = "Admin,User")] - OR
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ILogger<AdminController> logger
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    ViewData["ErrorMessage"] = $"User with id {id} is not found";
                    return View("NotFound");
                }

                var userClaims = await _userManager.GetClaimsAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);

                var model = new EditUserViewModel();
                model.Id = user.Id;
                model.Email = user.Email;
                model.UserName = user.UserName;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Claims = userClaims.Select(c => c.Value).ToList();
                model.Roles = userRoles.ToList();



                //foreach (var user in _userManager.Users)
                //{
                //    if (await _userManager.IsInRoleAsync(user, role.Name))
                //    {
                //        model.Users.Add(user.UserName);
                //    }
                //}

                return View(model);

            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    ViewData["ErrorMessage"] = $"User with id {model.Id} is not found";
                    return View("NotFound");
                }
                else
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.UserName = model.UserName;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListUsers");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

                return View(model);

            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    ViewData["ErrorMessage"] = $"User with id {id} is not found";
                    return View("NotFound");
                }
                else
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListUsers");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View("ListUsers");

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = model.RoleName;

                    IdentityResult result = await _roleManager.CreateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles", "Admin");
                    }

                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    ViewData["ErrorMessage"] = $"Role with id {id} is not found";
                    return View("NotFound");
                }

                var model = new EditRoleViewModel();
                model.Id = role.Id;
                model.RoleName = role.Name;

                var userr = _userManager;

                foreach (var user in userr.Users)
                {
                    if (await userr.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }
                return View(model);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewData["ErrorMessage"] = $"Role with id {id} is not found";
                return View("NotFound");
            }
            else
            {

                try
                {
                    //throw new Exception("Test Exception");


                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError($"Error deleting role {ex}");

                    ViewData["ErrorTitle"] = $"{role.Name} role is in use";
                    ViewData["ErrorMessage"] = $"{role.Name} role cannot be deleted as there are users in this role." +
                    $"If you want to delete this role, please remove the users from the role and try to delete again";
                    return View("Error");
                }
            }

            return View("ListRoles");



        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewData["roleId"] = roleId;
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    ViewData["ErrorMessage"] = $"Role with id {roleId} is not found";
                    return View("NotFound");
                }

                var model = new List<UserRoleViewModel>();

                foreach (var user in _userManager.Users)
                {
                    var userRoleViewModel = new UserRoleViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                    };

                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }
                    model.Add(userRoleViewModel);
                }

                return View(model);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> models, string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    ViewData["ErrorMessage"] = $"Role with id {roleId} is not found";
                    return View("NotFound");
                }

                for (int i = 0; i < models.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(models[i].UserId);

                    IdentityResult result = null;

                    if (models[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Id)))
                    {
                        result = await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!(models[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Id))))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else { continue; }

                    if (result.Succeeded)
                    {
                        if (i < (models.Count - 1))
                            continue;
                        else
                            return RedirectToAction("EditRole", new { Id = roleId });

                    }
                }

                return RedirectToAction("EditRole", new { Id = roleId });

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    ViewData["ErrorMessage"] = $"Role with id {model.Id} is not found";
                    return View("NotFound");
                }
                else
                {
                    role.Name = model.RoleName;
                    var result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View(model);
                }


            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult UserManagement()

        {
            //var roles = _roleManager.Roles;
            //return View(roles);

            var users = _userManager.Users;
            return View(users);

            //return View();

        }


    }
}
