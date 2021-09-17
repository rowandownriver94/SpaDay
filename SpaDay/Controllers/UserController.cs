using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/user/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/user")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            ViewBag.Username = newUser.Username;
            ViewBag.Email = newUser.Email;
            ViewBag.Password = newUser.Password;
            ViewBag.verify = verify;
            ViewBag.DateJoined = newUser.DateJoined;

            if (newUser.Password == verify)
            {
                ViewBag.isError = false;
                return View("Index");
            }
            else
            {
                ViewBag.isError = true;
                ViewBag.Error = "Your passwords do not match! Try again!";
                return View("Add");
            }
        }
    }
}
