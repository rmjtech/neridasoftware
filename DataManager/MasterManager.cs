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
    public class MasterManager
    {
        List<MyCountry> ListCountry = new List<MyCountry>();
        List<MyCurrency> ListCurrency = new List<MyCurrency>();
        List<MyDepot> ListDepot = new List<MyDepot>();
        List<MyCity> ListCity = new List<MyCity>();
        List<MyTerminal> ListTerminal = new List<MyTerminal>();
        List<MyPort> ListPort = new List<MyPort>();


        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public MasterManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Country Master
        public List<MyCountry> GetCountryMaster(MyCountry Data)
        {
            DataTable dt = GetCountryValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCountry.Add(new MyCountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryCode = dt.Rows[i]["CountryCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    //Status = Int32.Parse(dt.Rows[i]["Status"].ToString())
                });
                
            }
            return ListCountry;
        }
        public List<MyCountry> GetCountryMasterRecord(MyCountry Data)
        {
            DataTable dt = GetCountryRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListCountry.Add(new MyCountry
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryCode = dt.Rows[i]["CountryCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    Status = St
                });
            }


            return ListCountry;
        }
        public List<MyCountry> InsertCountryMaster(MyCountry Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CountryMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CountryMaster(CountryCode,CountryName,Status) " +
                                     " values (@CountryCode,@CountryName,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CountryMaster SET CountryCode=@CountryCode,CountryName=@CountryName,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryCode", Data.CountryCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryName", Data.CountryName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CountryMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListCountry;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCountry;
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
        public DataTable GetCountryValues(MyCountry Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_CountryMaster";

            if (Data.CountryCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where CountryCode like '%" + Data.CountryCode + "%'";
                else
                    strWhere += " and CountryCode like '%" + Data.CountryCode + "%'";

            if (Data.CountryName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CountryName like '%" + Data.CountryName + "%'";
                else
                    strWhere += " and CountryName like '%" + Data.CountryName + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public DataTable GetCountryRecord(MyCountry Data)
        {
            string _Query = "Select * from NVO_CountryMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCountry> GetCommonCountryMaster(MyCountry Data)
        {
            DataTable dt = GetCommonCountryValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCountry.Add(new MyCountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),

                });

            }
            return ListCountry;
        }

        public DataTable GetCommonCountryValues(MyCountry Data)
        {

            string _Query = "Select * from NVO_CountryMaster";
            return GetViewData(_Query, "");
        }
        #endregion

        #region Currency Master
        public List<MyCurrency> InsertCurrencyMaster(MyCurrency Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CurrencyMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CurrencyMaster(CurrencyCode,CurrencyName,Status) " +
                                     " values (@CurrencyCode,@CurrencyName,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CurrencyMaster SET CurrencyCode=@CurrencyCode,CurrencyName=@CurrencyName,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyCode", Data.CurrencyCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyName", Data.CurrencyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CurrencyMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListCurrency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCurrency;
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

        public List<MyCurrency> GetCurrrencyMaster(MyCurrency Data)
        {
            DataTable dt = GetCurrencyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurrency.Add(new MyCurrency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    //Status = Int32.Parse(dt.Rows[i]["Status"].ToString())
                });

            }
            return ListCurrency;
        }
        public List<MyCurrency> GetCurrencyMasterRecord(MyCurrency Data)
        {
            DataTable dt = GetCurrencyRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListCurrency.Add(new MyCurrency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    Status = St
                });
            }


            return ListCurrency;
        }
        public DataTable GetCurrencyValues(MyCurrency Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_CurrencyMaster";

            if (Data.CurrencyCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where CurrencyCode like '%" + Data.CurrencyCode + "%'";
                else
                    strWhere += " and CurrencyCode like '%" + Data.CurrencyCode + "%'";

            if (Data.CurrencyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CurrencyName like '%" + Data.CurrencyName + "%'";
                else
                    strWhere += " and CurrencyName like '%" + Data.CurrencyName + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public DataTable GetCurrencyRecord(MyCurrency Data)
        {
            string _Query = "Select * from NVO_CurrencyMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Depot Master
        public List<MyDepot> InsertDepotMaster(MyDepot Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_DepotMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_DepotMaster(DepName,DepAddress,DepCountry,DepCity,Status) " +
                                     " values (@DepName,@DepAddress,@DepCountry,@DepCity,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_DepotMaster SET DepName=@DepName,DepAddress=@DepAddress,DepCountry=@DepCountry,DepCity=@DepCity,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepName", Data.DepName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepAddress", Data.DepAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepCountry", Data.DepCountry));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepCity", Data.DepCity));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_DepotMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListDepot;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListDepot;
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

        public List<MyDepot> GetDepotMaster(MyDepot Data)
        {
            DataTable dt = GetDepotSearchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                ListDepot.Add(new MyDepot
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString(),
                    DepCountryName = dt.Rows[i]["CountryV"].ToString(),
                    DepCityName = dt.Rows[i]["CityV"].ToString(),
                    StatusName = dt.Rows[i]["StatusV"].ToString()
                });
                

            }
            return ListDepot;

            
        }

        public List<MyDepot> GetDepotMasterRecord(MyDepot Data)
        {
            DataTable dt = GetDepotMasterRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //int St = 0;
                //if (dt.Rows[i]["Status"].ToString() != "")
                //{
                //    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                //}
                //else
                //{
                //    St = 0;
                //}
                ListDepot.Add(new MyDepot
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString(),
                    DepAddress = dt.Rows[i]["DepAddress"].ToString(),
                    DepCountry = Int32.Parse(dt.Rows[i]["DepCountry"].ToString()),
                    DepCity = Int32.Parse(dt.Rows[i]["DepCity"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }


            return ListDepot;
        }
        public DataTable GetDepotMasterRecordValues(MyDepot Data)
        {
            string _Query = "select *  from NVO_DepotMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetDepotSearchValues(MyDepot Data)
        {
            string strWhere = "";

            string _Query = " Select ID,DepName,(select CountryName from NVO_CountryMaster where ID= DepCountry) as CountryV, " +
                            " (select CityName from NVO_CityMaster where ID = DepCity) as CityV, " +
                            " Case when Status = 0 then 'Inactive' else 'Active' end as StatusV " +
                            " from NVO_DepotMaster";

            if (Data.DepName != "")
                if (strWhere == "")
                    strWhere += _Query + " where DepName like '%" + Data.DepName + "%'";
                else
                    strWhere += " and DepName like '%" + Data.DepName + "%'";

           

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        #endregion

        #region Depot Master
        public List<MyTerminal> InsertTerminalMaster(MyTerminal Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_TerminalMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_TerminalMaster(TerminalCode,TerminalName,PortID,Status) " +
                                     " values (@TerminalCode,@TerminalName,@PortID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_TerminalMaster SET TerminalCode=@TerminalCode,TerminalName=@TerminalName,PortID=@PortID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalCode", Data.TerminalCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalName", Data.TerminalName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_TerminalMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListTerminal;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListTerminal;
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
        public List<MyPort> GetCommonPortMaster(MyPort Data)
        {
            DataTable dt = GetCommonPortValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MyPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                });

            }
            return ListPort;
        }

        public DataTable GetCommonPortValues(MyPort Data)
        {
            string _Query = "Select * from NVO_PortMaster";
            return GetViewData(_Query, "");
        }
        public List<MyTerminal> GetTerminalMaster(MyTerminal Data)
        {
            DataTable dt = GetTerminalSearchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTerminal.Add(new MyTerminal
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalCode = dt.Rows[i]["TerminalCode"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    PortName = dt.Rows[i]["PortV"].ToString(),
                    StatusName = dt.Rows[i]["StatusV"].ToString()
                });


            }
            return ListTerminal;


        }

        public List<MyTerminal> GetTerminalMasterRecord(MyTerminal Data)
        {
            DataTable dt = GetTerminalMasterRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTerminal.Add(new MyTerminal
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalCode = dt.Rows[i]["TerminalCode"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }


            return ListTerminal;
        }
        public DataTable GetTerminalMasterRecordValues(MyTerminal Data)
        {
            string _Query = "select *  from NVO_TerminalMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetTerminalSearchValues(MyTerminal Data)
        {
            string strWhere = "";

            string _Query = " select ID, TerminalCode, TerminalName,(select PortName from NVO_PortMaster where ID = PortID)as PortV, " +
                            " Case when Status = 0 then 'Inactive' else 'Active' end as StatusV from NVO_TerminalMaster";

            if (Data.TerminalCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where TerminalCode like '%" + Data.TerminalCode + "%'";
                else
                    strWhere += " and TerminalCode like '%" + Data.TerminalCode + "%'";

            if (Data.TerminalName != "")
                if (strWhere == "")
                    strWhere += _Query + " where TerminalName like '%" + Data.TerminalName + "%'";
                else
                    strWhere += " and TerminalName like '%" + Data.TerminalName + "%'";



            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        #endregion

        #region City Master
        public List<MyCity> GetCommonCityMaster(MyCity Data)
        {
            DataTable dt = GetCommonCityValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MyCity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),

                });

            }
            return ListCity;
        }
        public DataTable GetCommonCityValues(MyCity Data)
        {

            string _Query = "Select * from NVO_CityMaster";
            return GetViewData(_Query, "");
        }
        #endregion
        public DataTable GetViewData(string Query, string CmdType)
        {
            DbConnection con = null;
            DataTable DT = null;
            try
            {
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();

                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;

                    if (CmdType == "SP")
                        cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    DbDataAdapter adapter = _dbFactory.GetAdapter();
                    adapter.SelectCommand = cmd;
                    DT = new DataTable();
                    adapter.Fill(DT);
                }
                return DT;

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

        public string Getvalue(string Query)
        {
            DbConnection con = null;
            try
            {
                string Result = "";
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();
                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    object objresult = cmd.ExecuteScalar();
                    if (objresult != null)
                        Result = objresult.ToString();

                }
                return Result;

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

    }
}
