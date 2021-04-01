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
    public class RegistrationManager
    {
        List<MyDataBusinessLogic> List = new List<MyDataBusinessLogic>();
        List<MyMenu> ListMenu = new List<MyMenu>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public RegistrationManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Public Method
        public List<MyMenu> MenusMaster(MyMenu Data)
        {
            DataTable dt = GetMenusValuesFirst();
            // string HTMStr = "";
            string HTMStr = "<li class='nav-item active'><a class='nav-link' href='dashboard.html'><i class='material-icons'>dashboard</i><p>Dashboard</p></a></li>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HTMStr += "<li class='nav-item'><a class='nav-link' data-toggle='collapse' href='#" + dt.Rows[i]["FileName"].ToString() + "'><i class='material-icons'>groups</i>" +
                           "<p>" + dt.Rows[i]["FileName"].ToString() + "<b class='caret'></b></p></a>";

                DataTable _dtMTwo = GetMenusValuesTow(dt.Rows[i]["ID"].ToString());
                if (_dtMTwo.Rows.Count > 0)
                {
                    HTMStr += "<div class='collapse' id='" + dt.Rows[i]["FileName"].ToString() + "'><ul class='nav'>";
                    for (int j = 0; j < _dtMTwo.Rows.Count; j++)
                    {
                        HTMStr += "<li class='nav-item'> " +
                                  "<a class='nav-link' href=" + _dtMTwo.Rows[j]["Url"].ToString() + "><i class='material-icons'>double_arrow</i>" +
                                  "<span class='sidebar-normal'>" + _dtMTwo.Rows[j]["FileName"].ToString() + "</span> " +
                                  "</a></li>";
                    }
                    HTMStr += "</ul></div><li>";
                }
            }
            ListMenu.Add(new MyMenu
            {
                Url = HTMStr

            });
            return ListMenu;
        }
        public DataTable GetMenusValuesFirst()
        {
            string _Query = " select * from NVO_Menu where MenuId=0";
            return GetViewData(_Query, "");
        }

        public DataTable GetMenusValuesTow(string MenuID)
        {
            string _Query = " select * from NVO_Menu where MenuId=" + MenuID;
            return GetViewData(_Query, "");

        }
        public List<MyDataBusinessLogic> InsertUserMaster(MyDataBusinessLogic Data)
        {

            int r1 = 0;
            int r2 = 0;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_Reg where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Reg(Name,Mobile,Email,UserName,Password,UserCode,Location,Designation,Branch,Address,CurrentDate) " +
                                     " values (@Name,@Mobile,@Email,@UserName,@Password,@UserCode,@Location,@Designation,@Branch,@Address,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Reg SET Name=@Name,Mobile=@Mobile,Email=@Email,UserName=@UserName,Password=@Password,UserCode=@UserCode,Location=@Location,Designation=@Designation,Branch=@Branch,Address=@Address,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Name", Data.Name));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Mobile", Data.MobileNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Email", Data.Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserCode", Data.UserCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Location", Data.Location));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Designation", Data.Designation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", Data.Branch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_Reg')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return List;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MyDataBusinessLogic> LoginValues(MyDataBusinessLogic Data)
        {
            DataTable dt = ExistingUser(Data);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List.Add(new MyDataBusinessLogic
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        user = dt.Rows[i]["UserName"].ToString(),
                    });
                }
            }
            else
            {
                List.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse("0")
                });
            }

            return List;
        }

        

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
        public DataTable ExistingUser(MyDataBusinessLogic Data)
        {
            string _query = "select * from NVO_Reg where  UserName='" + Data.UserName + "' and Password='" + Data.Password + "'";
            return GetViewData(_query, "");

        }
       
            #endregion


        }
}
