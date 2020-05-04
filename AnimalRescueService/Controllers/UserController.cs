using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimalRescueApp;
using AnimalRescueService.Models;

namespace AnimalRescueService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        AnimalRescueRepo rep;

        public UserController()
        {
            rep = new AnimalRescueRepo();
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<UserDetails> users = new List<UserDetails>();
            try
            {
                var userList = rep.GetAllUsers();
                if (userList != null)
                {
                    foreach (var user in userList)
                    {
                        users.Add(new UserDetails()
                        {
                            UserName = user.UserName,
                            DisplayName = user.DisplayName,
                            Address = user.Address,
                            Contact = user.Contact
                        });
                    }
                    return Json(users);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public JsonResult RegisterUser(UserDetails user)
        {
            try
            {
                int res=rep.RegisterUser(new AnimalRescueApp.Models.UserDetails()
                {
                    UserName=user.UserName, DisplayName=user.DisplayName,
                    Contact=user.Contact,Address=user.Address, Password=user.Password
                });
                return Json(res);
            }
            catch (Exception)
            {
                return Json(-99);
            }
        }

        [HttpPost]
        public JsonResult UserLogin(string username, string password)
        {
            try
            {
                string res = rep.ValidateUser(username, password);
                return Json(res);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}