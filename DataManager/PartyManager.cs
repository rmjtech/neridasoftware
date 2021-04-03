using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using DataBaseFactory;
using System.Data;
using System.Data.Common;
using DataTier;
using System.Data.SqlClient;


namespace DataManager
{
    public class PartyManager
    {
        MasterManager cm = new MasterManager();
        List<MyAgency> ListAgency = new List<MyAgency>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public PartyManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Agency Master
        public List<MyAgency> InsertAgencyMaster(MyAgency Data)
        {


            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_AgencyMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                          " INSERT INTO  NVO_AgencyMaster(AgencyName,AgencyCode,CountryID,CityID,StateID,TaxGSTNo,OrganizationType,OwnOffice,DocumentSuffix,RegPanNO,Status,Address,Notes) " +
                                     " values (@AgencyName,@AgencyCode,@CountryID,@CityID,@StateID,@TaxGSTNo,@OrganizationType,@OwnOffice,@DocumentSuffix,@RegPanNO,@Status,@Address,@Notes) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_AgencyMaster SET AgencyName=@AgencyName,AgencyCode=@AgencyCode,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,TaxGSTNo=@TaxGSTNo,OrganizationType=@OrganizationType,OwnOffice=@OwnOffice,DocumentSuffix=@DocumentSuffix,RegPanNO=@RegPanNO,Status=@Status,Address=@Address,Notes=@Notes where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyName", Data.AgencyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyCode", Data.AgencyCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGSTNo", Data.TaxGSTNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnOffice", Data.OwnOffice));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentSuffix", Data.DocumentSuffix));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OrganizationType", Data.OrganizationType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RegPanNO", Data.RegPanNO));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", Data.Notes));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListAgency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgency;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyAgency> GetAgencyMaster(MyAgency Data)
        {
            DataTable dt = GetAgencyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgency.Add(new MyAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyCode = dt.Rows[i]["agencycode"].ToString(),
                    AgencyName = dt.Rows[i]["agencyname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    CityName = dt.Rows[i]["cityname"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),

                });
            }
            return ListAgency;
        }
        public DataTable GetAgencyValues(MyAgency Data)
        {
            string strWhere = "";

            string _Query = "select am.id,cm.id as CountryID,agencycode,agencyname,cm.CountryName,Address,ctm.cityname  " +
                   " from NVO_AgencyMaster am inner join NVO_CityMaster ctm on ctm.id = am.CityID " +
                    " left join NVO_CountryMaster cm on cm.id = am.CountryID";

            if (Data.AgencyCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where agencycode like '%" + Data.AgencyCode + "%'";
                else
                    strWhere += " and agencycode like '%" + Data.AgencyCode + "%'";

            if (Data.AgencyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where agencyname like '%" + Data.AgencyName + "%'";
                else
                    strWhere += " and agencyname like '%" + Data.AgencyName + "%'";

            if (Data.CountryID != "")
                if (strWhere == "")
                    strWhere += _Query + " Where am.CountryID=" + Data.CountryID;
                else
                    strWhere += " and am.CountryID =" + Data.CountryID;





            if (strWhere == "")
                strWhere = _Query;

            return cm.GetViewData(strWhere, "");

        }

        public List<MyAgency> GetAgencyMasterRecord(MyAgency Data)
        {
            DataTable dt = GetAgencyRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgency.Add(new MyAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyCode = dt.Rows[i]["AgencyCode"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    DocumentSuffix = dt.Rows[i]["DocumentSuffix"].ToString(),
                    RegPanNO = dt.Rows[i]["RegPanNO"].ToString(),
                    TaxGSTNo = dt.Rows[i]["TaxGSTNo"].ToString(),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),
                    CityID = dt.Rows[i]["CityID"].ToString(),
                    OrganizationType = dt.Rows[i]["OrganizationType"].ToString(),
                    OwnOffice = dt.Rows[i]["OwnOffice"].ToString(),
                    StateID = dt.Rows[i]["StateID"].ToString(),
                });
            }


            return ListAgency;
        }

        public DataTable GetAgencyRecord(MyAgency Data)
        {
            string _Query = "Select * from NVO_AgencyMaster where ID=" + Data.ID;
            return cm.GetViewData(_Query, "");
        }
        #endregion
    }
}
