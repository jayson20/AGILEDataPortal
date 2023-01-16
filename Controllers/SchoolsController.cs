using AGILEClassLibrary;
using AGILEDataPortal.Models;
using AGILEDataPortal.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AGILEDataPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SchoolsController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<School> _schools = new List<School>();

        School _school = new School();

        public SchoolsController(ISchoolUploadRepo repository)
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, chat, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _schools = new List<School>();
            var domain = "https://eregapis-agileapi.azurewebsites.net/api/schools/GetSchools";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(domain))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _schools = JsonConvert.DeserializeObject<List<School>>(apiResponse);
                }
            }

            return View(_schools);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            //var _school = new School();

            var domain = "https://eregapis-agileapi.azurewebsites.net/api/schools/GetSchool/";


            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{domain}{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _school = JsonConvert.DeserializeObject<School>(apiResponse);
                }
            }

            var school = new SchoolDetailViewModel();


            school.SchoolId = _school.Id;
            school.Name = _school.Name;
            school.UniqueName = _school.UniqueName;
            school.LGA = _school.LGA;
            school.Longitude = _school.Longitude;
            school.Latitude = _school.Latitude;
            school.ScreenProjector = _school.ScreenProjector;
            school.Address = _school.Address;
            school.InternetAvailability = _school.InternetAvailability;
            school.InternetRating = _school.InternetRating;
            school.PerimeterFence = _school.PerimeterFence;
            school.SchoolType1 = _school.SchoolType1;
            school.SchoolType2 = _school.SchoolType2;
            school.SchoolType3 = _school.SchoolType3;
            school.SchoolType4 = _school.SchoolType4;
            school.TypeOfInternet = _school.TypeOfInternet;
            school.State = _school.State;
            school.CCTV = _school.CCTV;
            school.NumberOfBoysJss1 = _school.NumberOfBoysJss1;
            school.NumberOfBoysJss2 = _school.NumberOfBoysJss2;
            school.NumberOfBoysJss3 = _school.NumberOfBoysJss2;
            school.NumberOfBoysSss1 = _school.NumberOfBoysSss1;
            school.NumberOfBoysSss2 = _school.NumberOfBoysSss2;
            school.NumberOfBoysSss3 = _school.NumberOfBoysSss3;

            school.NumberOfGirlsJss1 = _school.NumberOfGirlsJss1;
            school.NumberOfGirlsJss2 = _school.NumberOfGirlsJss2;
            school.NumberOfGirlsJss3 = _school.NumberOfGirlsJss3;
            school.NumberOfGirlsSss1 = _school.NumberOfGirlsSss1;
            school.NumberOfGirlsSss2 = _school.NumberOfGirlsSss2;
            school.NumberOfGirlsSss3 = _school.NumberOfGirlsSss3;

            school.TotalNumberOfStudents = _school.TotalNumberOfStudents;

            school.NumberOfICTTeachers = _school.NumberOfICTTeachers;
            school.NumberOfCompLabs = _school.NumberOfCompLabs;
            school.NumberOfComputersInLabs = _school.NumberOfComputersInLabs;
            school.NumberOfDesktops = _school.NumberOfDesktops;
            school.Software = _school.Software;
            school.NumberOfLaptops = _school.NumberOfLaptops;
            school.NumberOfColorPrinter = _school.NumberOfColorPrinter;
            school.NumberOfBlackAndWhitePrinter = _school.NumberOfBlackAndWhitePrinter;

            school.SecurityWindows = _school.SecurityWindows;
            school.SecurityDoors = _school.SecurityDoors;
            school.SecurityGateman = _school.SecurityGateman;
            school.SecurityNightGuard = _school.SecurityNightGuard;

            school.PowerSource_Public = _school.PowerSource_Public;
            school.PowerSource_Solar = _school.PowerSource_Solar;
            school.PowerSource_Generator = _school.PowerSource_Generator;
            school.PowerSource_Iverter = _school.PowerSource_Iverter;

            school.TelcoServicesMTN = _school.TelcoServicesMTN;
            school.TelcoServicesAirtel = _school.TelcoServicesAirtel;
            school.TelcoServicesGlo = _school.TelcoServicesGlo;
            school.TelcoServices9Mobile = _school.TelcoServices9Mobile;

            school.NetwPerihpRouters = _school.NetwPerihpRouters;
            school.NetwPerihpSwitches = _school.NetwPerihpSwitches;
            school.NetwPerihpCables = _school.NetwPerihpCables;
            school.LAN = _school.LAN;


            return View(school);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                var domain = "https://eregapis-agileapi.azurewebsites.net/api/schools/GetSchool/";


                using (var httpClient = new HttpClient(_clientHandler))
                {
                    using (var response = await httpClient.GetAsync($"{domain}{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _school = JsonConvert.DeserializeObject<School>(apiResponse);
                    }
                }

                var school = new SchoolEditViewModel();


                school.SchoolId = _school.Id;
                school.Name = _school.Name;
                school.UniqueName = _school.UniqueName;
                school.LGA = _school.LGA;
                school.Longitude = _school.Longitude;
                school.Latitude = _school.Latitude;
                school.ScreenProjector = _school.ScreenProjector;
                school.Address = _school.Address;
                school.InternetAvailability = _school.InternetAvailability;
                school.InternetRating = _school.InternetRating;
                school.PerimeterFence = _school.PerimeterFence;
                school.SchoolType1 = _school.SchoolType1;
                school.SchoolType2 = _school.SchoolType2;
                school.SchoolType3 = _school.SchoolType3;
                school.SchoolType4 = _school.SchoolType4;
                school.TypeOfInternet = _school.TypeOfInternet;
                school.State = _school.State;
                school.CCTV = _school.CCTV;
                school.NumberOfBoysJss1 = _school.NumberOfBoysJss1;
                school.NumberOfBoysJss2 = _school.NumberOfBoysJss2;
                school.NumberOfBoysJss3 = _school.NumberOfBoysJss2;
                school.NumberOfBoysSss1 = _school.NumberOfBoysSss1;
                school.NumberOfBoysSss2 = _school.NumberOfBoysSss2;
                school.NumberOfBoysSss3 = _school.NumberOfBoysSss3;

                school.NumberOfGirlsJss1 = _school.NumberOfGirlsJss1;
                school.NumberOfGirlsJss2 = _school.NumberOfGirlsJss2;
                school.NumberOfGirlsJss3 = _school.NumberOfGirlsJss3;
                school.NumberOfGirlsSss1 = _school.NumberOfGirlsSss1;
                school.NumberOfGirlsSss2 = _school.NumberOfGirlsSss2;
                school.NumberOfGirlsSss3 = _school.NumberOfGirlsSss3;

                school.TotalNumberOfStudents = _school.TotalNumberOfStudents;

                school.NumberOfICTTeachers = _school.NumberOfICTTeachers;
                school.NumberOfCompLabs = _school.NumberOfCompLabs;
                school.NumberOfComputersInLabs = _school.NumberOfComputersInLabs;
                school.NumberOfDesktops = _school.NumberOfDesktops;
                school.Software = _school.Software;
                school.NumberOfLaptops = _school.NumberOfLaptops;
                school.NumberOfColorPrinter = _school.NumberOfColorPrinter;
                school.NumberOfBlackAndWhitePrinter = _school.NumberOfBlackAndWhitePrinter;

                school.SecurityWindows = _school.SecurityWindows;
                school.SecurityDoors = _school.SecurityDoors;
                school.SecurityGateman = _school.SecurityGateman;
                school.SecurityNightGuard = _school.SecurityNightGuard;

                school.PowerSource_Public = _school.PowerSource_Public;
                school.PowerSource_Solar = _school.PowerSource_Solar;
                school.PowerSource_Generator = _school.PowerSource_Generator;
                school.PowerSource_Iverter = _school.PowerSource_Iverter;

                school.TelcoServicesMTN = _school.TelcoServicesMTN;
                school.TelcoServicesAirtel = _school.TelcoServicesAirtel;
                school.TelcoServicesGlo = _school.TelcoServicesGlo;
                school.TelcoServices9Mobile = _school.TelcoServices9Mobile;

                school.NetwPerihpRouters = _school.NetwPerihpRouters;
                school.NetwPerihpSwitches = _school.NetwPerihpSwitches;
                school.NetwPerihpCables = _school.NetwPerihpCables;
                school.LAN = _school.LAN;

                return View(school);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolEditViewModel model)
        {
            model.UniqueName = "Name";
            if (ModelState.IsValid)
            {
                //_school = new School();

                var domainGet = "https://eregapis-agileapi.azurewebsites.net/api/schools/GetSchool/";


                var httpClient = new HttpClient(_clientHandler);


                var response = await httpClient.GetAsync($"{domainGet}{model.Id}");

                string apiResponse = await response.Content.ReadAsStringAsync();
                _school = JsonConvert.DeserializeObject<School>(apiResponse);



                var school = new SchoolEditViewModel();


                _school.SchoolId = model.Id;
                _school.Name = model.Name;
                _school.UniqueName = model.UniqueName;
                _school.LGA = model.LGA;
                _school.Longitude = model.Longitude;
                _school.Latitude = model.Latitude;
                _school.ScreenProjector = model.ScreenProjector;
                _school.Address = model.Address;
                _school.InternetAvailability = model.InternetAvailability;
                _school.InternetRating = model.InternetRating;
                _school.PerimeterFence = model.PerimeterFence;
                _school.SchoolType1 = model.SchoolType1;
                _school.SchoolType2 = model.SchoolType2;
                _school.SchoolType3 = model.SchoolType3;
                _school.SchoolType4 = model.SchoolType4;
                _school.TypeOfInternet = model.TypeOfInternet;
                _school.State = model.State;
                _school.CCTV = model.CCTV;
                _school.NumberOfBoysJss1 = model.NumberOfBoysJss1;
                _school.NumberOfBoysJss2 = model.NumberOfBoysJss2;
                _school.NumberOfBoysJss3 = model.NumberOfBoysJss2;
                _school.NumberOfBoysSss1 = model.NumberOfBoysSss1;
                _school.NumberOfBoysSss2 = model.NumberOfBoysSss2;
                _school.NumberOfBoysSss3 = model.NumberOfBoysSss3;

                _school.NumberOfGirlsJss1 = model.NumberOfGirlsJss1;
                _school.NumberOfGirlsJss2 = model.NumberOfGirlsJss2;
                _school.NumberOfGirlsJss3 = model.NumberOfGirlsJss3;
                _school.NumberOfGirlsSss1 = model.NumberOfGirlsSss1;
                _school.NumberOfGirlsSss2 = model.NumberOfGirlsSss2;
                _school.NumberOfGirlsSss3 = model.NumberOfGirlsSss3;

                _school.TotalNumberOfStudents = model.TotalNumberOfStudents;

                _school.NumberOfICTTeachers = model.NumberOfICTTeachers;
                _school.NumberOfCompLabs = model.NumberOfCompLabs;
                _school.NumberOfComputersInLabs = model.NumberOfComputersInLabs;
                _school.NumberOfDesktops = model.NumberOfDesktops;
                _school.Software = model.Software;
                _school.NumberOfLaptops = model.NumberOfLaptops;
                _school.NumberOfColorPrinter = model.NumberOfColorPrinter;
                _school.NumberOfBlackAndWhitePrinter = model.NumberOfBlackAndWhitePrinter;

                _school.SecurityWindows = model.SecurityWindows;
                _school.SecurityDoors = model.SecurityDoors;
                _school.SecurityGateman = model.SecurityGateman;
                _school.SecurityNightGuard = model.SecurityNightGuard;

                _school.PowerSource_Public = model.PowerSource_Public;
                _school.PowerSource_Solar = model.PowerSource_Solar;
                _school.PowerSource_Generator = model.PowerSource_Generator;
                _school.PowerSource_Iverter = model.PowerSource_Iverter;

                _school.TelcoServicesMTN = model.TelcoServicesMTN;
                _school.TelcoServicesAirtel = model.TelcoServicesAirtel;
                _school.TelcoServicesGlo = model.TelcoServicesGlo;
                _school.TelcoServices9Mobile = model.TelcoServices9Mobile;

                _school.NetwPerihpRouters = model.NetwPerihpRouters;
                _school.NetwPerihpSwitches = model.NetwPerihpSwitches;
                _school.NetwPerihpCables = model.NetwPerihpCables;
                _school.LAN = model.LAN;


                var domainUpdate = "https://eregapis-agileapi.azurewebsites.net/api/schools/UpdateSchool";

                try
                {
                    using (var httpClient1 = new HttpClient(_clientHandler))
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(_school), Encoding.UTF8, "application/json");

                        using (var response1 = await httpClient.PutAsync(domainUpdate, content))
                        {
                            string apiResponse1 = await response1.Content.ReadAsStringAsync();
                            //_school = JsonConvert.DeserializeObject<School>(apiResponse1);
                        }
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }

                ViewBag.message = "Records updated succefully!!!";

                return View();

                //return RedirectToAction(nameof(Index));

            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var domain = "https://eregapis-agileapi.azurewebsites.net/api/schools/GetSchool/";


            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{domain}{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _school = JsonConvert.DeserializeObject<School>(apiResponse);
                }
            }

            var model = new SchoolDeleteViewModel()
            {
                Id = _school.Id,
                Name = _school.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SchoolDeleteViewModel model)
        {
            string message = "";

            var domain = "https://eregapis-agileapi.azurewebsites.net/api/schools/DeleteSchool?Id=";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{domain}{model.Id}"))
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
