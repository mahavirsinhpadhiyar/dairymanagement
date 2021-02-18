using DairyManagement.Models.LiveDBEDMX;
using DairyManagement.ViewModels.Login;
using System;
using DairyManagement.ViewModels.Accounts;
using DairyManagement.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    public class LoginController : HandleExceptionController
    {
        private dairymanagementEntities db = new dairymanagementEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                DateTime dt = new DateTime(2022, 1, 1);
                if (DateTime.Now > dt)
                {
                    ModelState.AddModelError("SubscriptionDateExpire", "કૃપા કરીને સેવાનો ઉપયોગ ચાલુ રાખવા માટે તમારા સબ્સ્ક્રિપ્શનને અપગ્રેડ કરો.");
                    return View(loginViewModel);
                }
                if (db.UserInfoes.FirstOrDefault(u => u.UserId == loginViewModel.Username && u.Password == loginViewModel.Password) != null)
                {
                    Session["isuserloggedin"] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["isuserloggedin"] = false;
                    loginViewModel.ErrorMessage = "દાખલ કરેલ વપરાશકર્તા નામ અથવા પાસવર્ડ ખોટો છે";
                }
            }

            Session["isuserloggedin"] = false;
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            Session["isuserloggedin"] = false;
            return RedirectToAction("Index");
        }
    }
}