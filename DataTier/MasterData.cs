using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MasterData
    {
       

      
    }
    public class MyCountry
    {
       
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CountryCode = string.Empty;
        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
     
    }

    public class MyCurrency
    {
        
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CurrencyCode = string.Empty;
        public string CurrencyCode { get { return _CurrencyCode; } set { _CurrencyCode = value; } }

        private string _CurrencyName = string.Empty;
        public string CurrencyName { get { return _CurrencyName; } set { _CurrencyName = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        
    }

    public class MyDepot
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _DepName = string.Empty;
        public string DepName { get { return _DepName; } set { _DepName = value; } }

        private string _DepAddress = string.Empty;
        public string DepAddress { get { return _DepAddress; } set { _DepAddress = value; } }

        private int _DepCountry;
        public int DepCountry { get { return _DepCountry; } set { _DepCountry = value; } }

        private int _DepCity;
        public int DepCity { get { return _DepCity; } set { _DepCity = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _DepCountryName = string.Empty;
        public string DepCountryName { get { return _DepCountryName; } set { _DepCountryName = value; } }

        private string _DepCityName = string.Empty;
        public string DepCityName { get { return _DepCityName; } set { _DepCityName = value; } }

        private string _StatusName = string.Empty;
        public string StatusName { get { return _StatusName; } set { _StatusName = value; } }

    }

    public class MyCity
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CityCode = string.Empty;
        public string CityCode { get { return _CityCode; } set { _CityCode = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

      
    }

    public class MyTerminal
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _TerminalCode = string.Empty;
        public string TerminalCode { get { return _TerminalCode; } set { _TerminalCode = value; } }

        private string _TerminalName = string.Empty;
        public string TerminalName { get { return _TerminalName; } set { _TerminalName = value; } }

        private int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _StatusName = string.Empty;
        public string StatusName { get { return _StatusName; } set { _StatusName = value; } }



    }
    public class MyPort
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

      
    }

}
