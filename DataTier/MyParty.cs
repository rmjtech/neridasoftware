using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyParty
    {
    }

    public class MyAgency
    {
        public int ID;
        private string _AgencyName = string.Empty;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }

        private string _AgencyCode = string.Empty;
        public string AgencyCode { get { return _AgencyCode; } set { _AgencyCode = value; } }

        private string _CountryID = string.Empty;
        public string CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private string _CityID = string.Empty;
        public string CityID { get { return _CityID; } set { _CityID = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StateID = string.Empty;
        public string StateID { get { return _StateID; } set { _StateID = value; } }

        private string _TaxGSTNo = string.Empty;
        public string TaxGSTNo { get { return _TaxGSTNo; } set { _TaxGSTNo = value; } }


        private string _RegPanNO = string.Empty;
        public string RegPanNO { get { return _RegPanNO; } set { _RegPanNO = value; } }

        private string _Address = string.Empty;
        public string Address { get { return _Address; } set { _Address = value; } }
        private string _Notes = string.Empty;
        public string Notes { get { return _Notes; } set { _Notes = value; } }



        private string _OrganizationType = string.Empty;
        public string OrganizationType { get { return _OrganizationType; } set { _OrganizationType = value; } }

        private string _OwnOffice = string.Empty;
        public string OwnOffice { get { return _OwnOffice; } set { _OwnOffice = value; } }

        private string _DocumentSuffix = string.Empty;
        public string DocumentSuffix { get { return _DocumentSuffix; } set { _DocumentSuffix = value; } }


    }
}
