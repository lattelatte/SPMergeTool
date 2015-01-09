using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SPMerge.Util
{
    public class CommonProcessor
    {
        public string SpName;
        public string TableName;
        public int Delta;
        public int SpId;
        private string[] _updateColumnsName;
        public string[] UpgradeColumnsName
        {
            get
            {
                return _updateColumnsName;
            }
            set
            {
                _updateColumnsName = value.Select(x => x.ToLower()).ToArray();
            }

        }
        public string[] SelectColumnsName;
        public Dictionary<string, string> ColumnValue;
        public bool IncludingSp = false;
        protected void RenderFile(StringBuilder sb)
        {
            string fileName = "./CreateFile/" + SpName + "/" + TableName + ".sql";
            if (File.Exists(fileName))
            {
                File.AppendAllText(fileName, sb.ToString());
                return;
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        public virtual void GenerateSQL()
        {
            string columnNames = "*";
            if (this.SelectColumnsName != null)
            {
                columnNames = string.Join(",", this.SelectColumnsName.ToArray());
            }
            string sql = @"select " + columnNames + " from [" + TableName + "]";

            DataTable dt = DBHelper.QuerySql(sql);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"if exists (select 1 from sys.identity_columns i inner join sys.objects o on i.object_id = o.object_id where o.object_id = OBJECT_ID(N'{0}')) SET IDENTITY_INSERT [{0}] ON", TableName));
            //sb.AppendLine("delete from [" + TableName + "] \r\n");
            string pattern = "insert into [" + TableName + "]({0}) values({1})";
            long idx = 0;
            foreach (DataRow row in dt.Rows)
            {
                List<string> columns = new List<string>();
                List<string> values = new List<string>();
                idx++;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName.ToLower() == "version")
                    {
                        continue;
                    }
                    else
                    {
                        columns.Add("[" + column.ColumnName + "]");
                        if (row[column] is DBNull)
                        {
                            values.Add("null");
                        }
                        else if (column.DataType.Name == "SqlHierarchyId")
                        {
                            values.Add("0x");

                        }
                        else if (this.UpgradeColumnsName.Contains(column.ColumnName.ToLower()))
                        {

                            if (column.DataType == typeof(string))
                            {
                                string v = row[column].ToString().Replace("'", "''");
                                if (!string.IsNullOrWhiteSpace(v))
                                {
                                    if (this.TableName == "Tag")
                                    {
                                        v = this.GetFormula(v);
                                    }
                                    else if (this.TableName == "VEEAnomalyRecord")
                                    {
                                        v = this.GetVEE(v);
                                    }

                                    if (column.ColumnName == "ContentSyntax")
                                    {
                                        v = this.GetSyntax(v);
                                    }
                                }
                                values.Add("N'" + v + "'");
                            }
                            else
                            {
                                long newid = long.Parse(row[column].ToString());
                                if (newid > 0)
                                {
                                    if (this.IncludingSp == false)
                                    {
                                        int m = 1;
                                        if (TableName == "Widget" && column.ColumnName == "Id")
                                        {
                                            m = 7;
                                        }
                                        else if (TableName == "Dashboard" && column.ColumnName == "Id")
                                        {
                                            m = 2;
                                        }
                                        else if (column.ColumnName.Contains("WidgetId"))
                                        {
                                            m = 7;
                                        }
                                        else if (column.ColumnName.Contains("DashboardId"))
                                        {
                                            m = 2;
                                        }
                                        newid = newid + Delta * m;
                                    }
                                    else
                                    {
                                        int dd = int.Parse(row["ServiceProviderId"].ToString());
                                        int ddd = 0;
                                        foreach (KeyValuePair<string, int[]> item in DBHelper.DBMapper)
                                        {
                                            if (item.Value[1] == dd)
                                            {
                                                ddd = item.Value[0];
                                                break;
                                            }
                                        }
                                        newid += ddd;
                                    }
                                }
                                values.Add(newid.ToString());
                            }
                        }
                        else
                        {

                            if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                            {
                                values.Add("N'" + row[column].ToString().Replace("'", "''") + "'");
                            }
                            else if (column.DataType == typeof(byte[]))//to do
                            {
                                values.Add("0x");
                            }
                            else if (column.DataType == typeof(bool))
                            {
                                values.Add(bool.Parse(row[column].ToString()) == true ? "1" : "0");
                            }
                            else
                            {
                                values.Add(row[column].ToString());
                            }
                        }
                    }
                }

                if (this.UpgradeColumnsName.Contains("spid"))
                {
                    columns.Add("[SpId]");
                    values.Add(this.SpId.ToString());
                }

                if (this.ColumnValue != null)
                {
                    if (this.ColumnValue.ContainsKey(row["Id"].ToString()))
                    {
                        string v = this.ColumnValue[row["Id"].ToString()];
                        string[] arr = v.Split(',');

                        columns.Add(arr[0]);
                        values.Add(arr[1]);
                    }
                    else
                    {
                        continue;
                    }
                }

                sb.AppendLine(string.Format(pattern, string.Join(",", columns.ToArray()), string.Join(",", values.ToArray())));

                if (idx == 10000)
                {
                    RenderFile(sb);
                    sb = new StringBuilder();
                    idx = 0;
                }
            }
            sb.AppendLine(string.Format(@"if exists (select 1 from sys.identity_columns i inner join sys.objects o on i.object_id = o.object_id where o.object_id = OBJECT_ID(N'{0}')) SET IDENTITY_INSERT [{0}] OFF", TableName));
            RenderFile(sb);
        }

        private string GetSyntax(string v)
        {
            string ret = v;

            Regex p = new Regex("(\"HierarchyId\"|\"SystemDimensionTemplateItemId\"|\"AreaDimensionId\"):(\\d+)");
            MatchCollection ms;
            ms = p.Matches(v);
            long id;
            foreach (Match item in ms)
            {
                id = long.Parse(item.Groups[2].Value);
                if (id > 0)
                {
                    id += Delta;
                }

                ret = p.Replace(ret, item.Groups[1].Value + ":" + id);

            }

            if (v.Contains("tagIds"))
            {
                p = new Regex("(\"HierId\"|\"Id\"):(\\d+)");

                ms = p.Matches(v);

                foreach (Match item in ms)
                {
                    id = long.Parse(item.Groups[2].Value);
                    if (id > 0)
                    {
                        id += Delta;
                    }

                    ret = ret.Replace(item.Value, item.Groups[1].Value + ":" + id);

                }



            }

            p = new Regex("(\"tagIds\"|\"hierarchyIds\"):\\[([\\d|,]*)\\]");

            ms = p.Matches(ret);
            foreach (Match item in ms)
            {

                string[] ids = item.Groups[2].Value.Split(',');
                List<string> l = new List<string>();
                foreach (string item1 in ids)
                {
                    id = long.Parse(item1);
                    if (id > 0)
                    {
                        id += Delta;
                    }
                    l.Add(id.ToString());
                }


                ret = p.Replace(ret, item.Groups[1].Value + ":[" + string.Join(",", l.ToArray()) + "]");
            }



            p = new Regex("\"seriesKey\":\"([^\\\"]*)\"");

            ms = p.Matches(ret);
            foreach (Match m in ms)
            {

                string[] items = m.Groups[1].Value.Split('_');

                string v1 = items[1];
                long lv1 = 0;
                if (v1 != "%" && !v1.Contains("+"))
                {
                    lv1 = long.Parse(v1);
                    if (lv1 > 0)
                    {
                        lv1 += Delta;
                        items[1] = lv1.ToString();
                    }
                }
                v1 = items[2];
                if (v1 != "%")
                {
                    string[] ps = v1.Split('/');
                    long mm = long.Parse(ps[1]);
                    if (mm > 0)
                    {
                        ps[1] = (mm + Delta).ToString();
                    }

                    if (ps.Length > 2)
                    {
                        mm = long.Parse(ps[2]);
                        if (mm > 0)
                        {
                            ps[2] = (mm + Delta).ToString();
                        }
                    }
                    items[2] = string.Join("/", ps);
                }

                ret = ret.Replace(m.Value, m.Value.Split(':')[0] + ":\"" + string.Join("_", items) + "\"");


            }

            return ret;
        }

        private string GetVEE(string v)
        {
            Regex p = new Regex("\"Id\":(\\d+)");
            string ret = v;
            Match m = p.Match(v);
            if (m.Success)
            {
                long id = long.Parse(m.Groups[1].Value);
                if (id > 0)
                {
                    id += Delta;
                }

                ret = p.Replace(v, "\"Id\":" + id);
            }
            return ret;

        }

        private string GetFormula(string v)
        {
            Regex p = new Regex("ptag\\|(\\d+)");
            string ret = v;
            long id = 0;
            Match m = p.Match(v);
            if (m.Success)
            {
                id = long.Parse(m.Groups[1].Value);
                if (id > 0)
                {
                    id += Delta;
                }

                ret = p.Replace(v, "ptag|" + id);
            }

            p = new Regex("vtag\\|(\\d+)");

            m = p.Match(v);
            if (m.Success)
            {
                id = long.Parse(m.Groups[1].Value);
                if (id > 0)
                {
                    id += Delta;
                }

                ret = p.Replace(ret, "vtag|" + id);

            }

            p = new Regex("prop\\|(\\d+)");

            m = p.Match(v);
            if (m.Success)
            {
                id = long.Parse(m.Groups[1].Value);
                if (id > 0)
                {
                    id += Delta;
                }

                ret = p.Replace(ret, "prop|" + id);
            }
            return ret;

        }
    }
}
