using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NVOCShipping.Models;

namespace NVOCShipping.Controllers
{
    public class PartyController : Controller
    {
        // GET: Party
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer()
        {
            ViewBag.Message = "Your Customer.";

            return View();
        }
    }
}