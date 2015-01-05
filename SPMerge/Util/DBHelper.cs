using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMerge.Util
{
    public class DBHelper
    {
        public static bool Test()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("select count(0) from sys.objects", conn))
                    {
                        int count = int.Parse(cmd.ExecuteScalar().ToString());
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }


            return false;
        }

        internal static string GetConnString()
        {
            string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            return connStr;
        }

        internal static void SaveConnString(string connStr)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["sql"].ConnectionString = connStr;
            
            config.Save();

            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static DataTable QuerySql(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;

        }


    }
}
