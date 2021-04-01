using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataManager;
using DataTier;

namespace NVOCShipping.api
{
    public class HomeController : ApiController
    {
        [ActionName("mainMenus")]
        public List<MyMenu> mainMenus(MyMenu Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyMenu> st = cm.MenusMaster(Data);
            return st;
        }

        [ActionName("Login")]
        public List<MyDataBusinessLogic> LogIn(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.LoginValues(Data);
            return st;
        }

      
        [ActionName("Register")]
        public List<MyDataBusinessLogic> Register(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.InsertUserMaster(Data);
            return st;
        }

        [ActionName("Country")]
        public List<MyCountry> Country(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.InsertCountryMaster(Data);
            return st;
        }
        [ActionName("Countryview")]
        public List<MyCountry> Countryview(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCountryMaster(Data);
            return st;
        }
        [ActionName("Countryviewparticular")]
        public List<MyCountry> Countryviewparticular(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCountryMasterRecord(Data);
            return st;
        }

        [ActionName("Currency")]
        public List<MyCurrency> Currency(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.InsertCurrencyMaster(Data);
            return st;
        }
        [ActionName("Currencyview")]
        public List<MyCurrency> Currencyview(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.GetCurrrencyMaster(Data);
            return st;
        }
        [ActionName("Currencyviewparticular")]
        public List<MyCurrency> Currencyviewparticular(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.GetCurrencyMasterRecord(Data);
            return st;
        }

        [ActionName("Depot")]
        public List<MyDepot> Depot(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.InsertDepotMaster(Data);
            return st;
        }

        [ActionName("countryBind")]
        public List<MyCountry> countryBind(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCommonCountryMaster(Data);
            return st;
        }

        [ActionName("cityBind")]
        public List<MyCity> cityBind(MyCity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.GetCommonCityMaster(Data);
            return st;
        }
        [ActionName("DepotView")]
        public List<MyDepot> DepotView(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetDepotMaster(Data);
            return st;
        }

        [ActionName("DepotRecord")]
        public List<MyDepot> DepotRecord(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetDepotMasterRecord(Data);
            return st;
        }
        [ActionName("Terminal")]
        public List<MyTerminal> Terminal(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.InsertTerminalMaster(Data);
            return st;
        }

        [ActionName("TerminalView")]
        public List<MyTerminal> TerminalView(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.GetTerminalMaster(Data);
            return st;
        }
        [ActionName("TerminalRecord")]
        public List<MyTerminal> TerminalRecord(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.GetTerminalMasterRecord(Data);
            return st;
        }
        [ActionName("portBind")]
        public List<MyPort> portBind(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetCommonPortMaster(Data);
            return st;
        }
    }
}