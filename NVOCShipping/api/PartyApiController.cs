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
    public class PartyApiController : ApiController
    {

        [ActionName("Customer")]
        public List<MyTerminal> Customer(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.InsertTerminalMaster(Data);
            return st;
        }
    }
}
