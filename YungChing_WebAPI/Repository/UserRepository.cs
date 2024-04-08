using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using YungChing_WebAPI.Common;

namespace YungChing_WebAPI.Repository
{
    public class UserRepository
    {
        public DataTable GetUser(string userid = null)
        {
            DataTable dt = new DataTable();

            string SqlStr = "SELECT * FROM UserData";
            if (userid != null)
                SqlStr += " WHERE UserID=@UserID";

            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("@UserID", userid));

            if (userid != null)
                dt = dbComm.getDataTable(SqlStr, ParameterList.ToArray());
            else
                dt = dbComm.getDataTable(SqlStr);

            return dt;
        }
        public int AddUser(string userid, string username)
        {
            int EffectCount = 0;

            string SqlStr = "INSERT INTO UserData(UserID,UserName)Values(@UserID,@UserName)";

            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("@UserID", userid));
            ParameterList.Add(new SqlParameter("@UserName", username));

            EffectCount = dbComm.UpdDataTable(SqlStr, ParameterList.ToArray());

            return EffectCount;
        }
        public int UpdUser(string userid, string username)
        {
            int EffectCount = 0;

            string SqlStr = "UPDATE UserData SET UserName=@UserName WHERE UserID = @UserID";

            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("@UserID", userid));
            ParameterList.Add(new SqlParameter("@UserName", username));

            EffectCount = dbComm.UpdDataTable(SqlStr, ParameterList.ToArray());

            return EffectCount;
        }
        public int DelUser(string userid)
        {
            int EffectCount = 0;

            string SqlStr = "DELETE FROM UserData WHERE UserID=@UserID";

            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("@UserID", userid));

            EffectCount = dbComm.UpdDataTable(SqlStr, ParameterList.ToArray());

            return EffectCount;
        }
    }
}