using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YungChing_WebAPI.Common
{
    public class dbComm
    {
        public static string ConnStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
        public static DataTable getDataTable(string sqlStr, SqlParameter[] sqlParams = null)
        {
            DataTable dt = new DataTable();
            try
            {
                if (sqlParams == null)
                {
                    dt = ExecuteQuery(sqlStr);
                }
                else
                {
                    dt = ExecuteQuery(sqlStr, sqlParams);
                }
            }
            catch (Exception ex)
            { }

            return dt;
        }
        public static int UpdDataTable(string sqlStr, SqlParameter[] sqlParams = null)
        {
            int EffectCount = 0;
            try
            {
                if (sqlParams == null)
                {
                    EffectCount = ExecuteNonQuery(sqlStr);
                }
                else
                {
                    EffectCount = ExecuteNonQuery(sqlStr, sqlParams);
                }
            }
            catch (Exception ex)
            { }

            return EffectCount;
        }
        public static DataTable ExecuteQuery(string sqlStr, SqlParameter[] sqlParams = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                try
                {
                    conn.Open(); ;

                    using (SqlCommand command = new SqlCommand(sqlStr, conn))
                    {
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter parameter in sqlParams)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        SqlDataAdapter sqlData = new SqlDataAdapter(command);
                        sqlData.Fill(dt);
                    }
                }
                catch (Exception ex)
                { }
            }

            return dt;
        }
        public static int ExecuteNonQuery(string sqlStr, SqlParameter[] sqlParams = null)
        {
            int EffectCount = 0;

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                try
                {
                    conn.Open(); ;

                    using (SqlCommand command = new SqlCommand(sqlStr, conn))
                    {
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter parameter in sqlParams)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        EffectCount = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                { }
            }

            return EffectCount;
        }
    }
}