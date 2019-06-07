using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars_Trade.Models;
using System.Web.Helpers;

namespace Cars_Trade.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Click_Client()//Enter like Client
        {
            Choose.choose = 1;
            return View("Client_fr");
        }

        public ActionResult Click_Employee()//Enter like Employee
        {
            Choose.choose = 2;
            return View("Password");
        }

        public ActionResult Click_admin()//Enter like Admin
        {
            Choose.choose = 3;
            return View("Password");
        }
        public ActionResult Click_OK()//Password
        {
            switch (Choose.choose)
            {
                case 2:
                    return View("Employee_fr");
                case 3:
                    return View("Admin_fr");
                default:
                    return View("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "О программе";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Информация";

            return View();
        }
    }
}