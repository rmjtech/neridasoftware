using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyDataBusinessLogic
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _Name = string.Empty;
        public string Name { get { return _Name; } set { _Name = value; } }

        private string _Designation = string.Empty;
        public string Designation { get { return _Designation; } set { _Designation = value; } }

        private DateTime _CurrentDate = DateTime.MinValue;
        public DateTime CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }

        private string _Branch = string.Empty;
        public string Branch { get { return _Branch; } set { _Branch = value; } }

        private int _Location;
        public int Location { get { return _Location; } set { _Location = value; } }

        private string _Email = string.Empty;
        public string Email { get { return _Email; } set { _Email = value; } }

        private string _UserName = string.Empty;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _UserCode = string.Empty;
        public string UserCode { get { return _UserCode; } set { _UserCode = value; } }

        


        private string _user = string.Empty;
        public string user { get { return _user; } set { _user = value; } }


        private string _Password = string.Empty;
        public string Password { get { return _Password; } set { _Password = value; } }

     

        private string _MobileNo = string.Empty;
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }

     

        private string _Address = string.Empty;
        public string Address { get { return _Address; } set { _Address = value; } }

      

        private string _LocationName = string.Empty;
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }

     
    }

    public class MyMenu
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _File = string.Empty;
        public string File { get { return _File; } set { _File = value; } }

        private string _Url = string.Empty;
        public string Url { get { return _Url; } set { _Url = value; } }

        private int _MenuID;
        public int MenuID { get { return _MenuID; } set { _MenuID = value; } }


    }

}
