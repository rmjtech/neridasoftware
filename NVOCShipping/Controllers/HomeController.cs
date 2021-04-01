using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NVOCShipping.Models;


namespace NVOCShipping.Controllers
{
   
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reg()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your Dashboard.";

            return View();
        }
        public ActionResult Location()
        {
            ViewBag.Message = "Your Dashboard.";

            return View();
        }
        public ActionResult Country(string id)
        {

            MasterModel BusData = new MasterModel();
            BusData.MasterDetails = new Masters();
            if (id != null)
                BusData.MasterDetails.ID = Int32.Parse(id);
            else
                BusData.MasterDetails.ID = 0;
            ViewBag.Message = "Your Country.";

            return View(BusData);
        }
        public ActionResult CountryView()
        {
            ViewBag.Message = "Your Country.";

            return View();
        }
        public ActionResult Currency(string id)
        {
            MasterModel BusData = new MasterModel();
            BusData.MasterDetails = new Masters();
            if (id != null)
                BusData.MasterDetails.ID = Int32.Parse(id);
            else
                BusData.MasterDetails.ID = 0;
            ViewBag.Message = "Your Currency.";

            return View(BusData);
          
        }
        public ActionResult CurrencyView()
        {
            ViewBag.Message = "Your Currency.";

            return View();
        }
        public ActionResult Depot(string id)
        {
            MasterModel BusData = new MasterModel();
            BusData.MasterDetails = new Masters();
            if (id != null)
                BusData.MasterDetails.ID = Int32.Parse(id);
            else
                BusData.MasterDetails.ID = 0;
            ViewBag.Message = "Your Depot.";

            return View(BusData);
        }
        public ActionResult DepotView()
        {
            ViewBag.Message = "Your DepotView.";

            return View();
        }
        public ActionResult Customer()
        {
            ViewBag.Message = "Your Customer.";

            return View();
        }

        public ActionResult Terminal(string id)
        {
            MasterModel BusData = new MasterModel();
            BusData.MasterDetails = new Masters();
            if (id != null)
                BusData.MasterDetails.ID = Int32.Parse(id);
            else
                BusData.MasterDetails.ID = 0;
            ViewBag.Message = "Your Terminal.";

            return View();
        }

        public ActionResult TerminalView()
        {
            ViewBag.Message = "Your TerminalView.";

            return View();
        }
    }
}