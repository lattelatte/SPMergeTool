using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SPMerge.Util
{
    public class DBHelper
    {
        internal static string DBName = null;
        internal static Dictionary<string, int> DBMapper = new Dictionary<string, int>();
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

            if (DBName != null)
            {
                Regex reg = new Regex("Database\\s*=\\s*([^;]*)");

                connStr = reg.Replace(connStr, "Database=" + DBName);
            }

            return connStr;
        }

        internal static void RestoreMetadataDB()
        {
            DBName = null;
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

        public static void ExecuteSqlFile(string filePath, string head, params string[] replacement)
        {
            string sql = string.Format(File.ReadAllText(filePath), replacement);

            sql = head + "GO\r\n" + sql;

            string[] commands = sql.Split(new string[] { "GO\r\n", "GO ", "GO\t", "go\r\n", "\r\nGO" }, StringSplitOptions.RemoveEmptyEntries);


            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                conn.Open();
                foreach (var item in commands)
                {
                    using (SqlCommand cmd = new SqlCommand(item, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        public static void ExecuteSql(string sql)
        {

            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }


        }


    }
}
