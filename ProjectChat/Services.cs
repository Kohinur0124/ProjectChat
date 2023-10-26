using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChat
{
    public class Services
    {
        public static bool Register(string TableName, string DatabaseName, List<InsertModel> columns)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {


                connect.Open();


                if (CheckUsername(TableName, DatabaseName, columns[2].Value1))
                {

                
                    string query = $"insert into {TableName}({String.Join(",", columns.Select(x => x.ColumnName).ToList())} )" +
                        $"Values" +
                        $"({String.Join(",", Shart(columns.Select(x => x.Value1).ToList()))});";



                    SqlCommand cmd = new SqlCommand(query, connect);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;


            }
        }


        public static List<string> Shart(List<string> lst)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < lst.Count; i++)
            {
                int num;
                var isnum = int.TryParse(lst[i], out num);
              
                if (isnum )
                {
                    s.Add(lst[i]);
                }
                else
                {
                    s.Add($"\'{lst[i]}\'");
                }
            }
            return s;
        }

        public static List<List<string>> GetAll(string TableName, string DatabaseName)
        {
            List<List<string>> list = new List<List<string>>();
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {
                connect.Open();

                string query = $"select * from {TableName} ;";

                SqlCommand sqlCommand = new SqlCommand(query, connect);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    //int i = 0;
                    while (reader.Read())
                    {
                        List<string> s = new List<string> ();
                        for (int j = 0; j < count; j++)
                        {
                            s.Add(reader[j].ToString());
                            
                        }
                        list.Add (s);
                    }
                }
            }
            return list;
        }

        public static bool CheckUsername(string TableName, string DatabaseName,string username)
        {
            bool t = false;
            var lst = GetAll(TableName, DatabaseName);
            var q = lst.Where(x => x[2]==username);
            if (q.Count() <= 0)
            { return true; }
            else return false;
        }

        public static List<string> GetUsername(string TableName, string DatabaseName, string username)
        {
            bool t = false;
            var lst = GetAll(TableName, DatabaseName);
            var q = lst.FirstOrDefault(x => x[2] == username);
            return q;
        }
        public static string  GetUsernameById(string TableName, string DatabaseName, string id)
        {
            
            var lst = GetAll(TableName, DatabaseName);
            var q = lst.FirstOrDefault(x => x[0] == id).ToList()[1];
            return q;
        }


        public static void insertInto(string TableName, string DatabaseName, List<InsertModel> columns)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {


                connect.Open();

                //string ustunlar = String.Empty;

                //string linq = String.Join(",", columns.Select(x => x.Name + " " + x.Typelari).ToList());

                //string query = $"create table {TableName}(Id int not null, " +
                //                                        $"Name varchar(30)," +
                //                                        $"Age int not null)";


                string query = $"insert into {TableName}({String.Join(",", columns.Select(x => x.ColumnName).ToList())} )" +
                    $"Values" +
                    $"({String.Join(",", Shart(columns.Select(x => x.Value1).ToList()))});";



                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.ExecuteNonQuery();

                

            }
        }


        public static List<List<string>> GetAllChats(string TableName, string DatabaseName,List<InsertModel> columns)
        {
            List<List<string>> list = new List<List<string>>();
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {
                connect.Open();

                string query = $"select * from Chats " +
                                    $"Where {columns[0].ColumnName} =  {columns[0].Value1} And " +
                                    $"{columns[1].ColumnName} =  {columns[1].Value1}  OR " +
                                    $"{columns[0].ColumnName} =  {columns[1].Value1} And " +
                                    $"{columns[1].ColumnName} =  {columns[0].Value1} ; ";

                SqlCommand sqlCommand = new SqlCommand(query, connect);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    //int i = 0;
                    while (reader.Read())
                    {
                        List<string> s = new List<string>();
                        for (int j = 0; j < count; j++)
                        {
                            s.Add(reader[j].ToString());

                        }
                        list.Add(s);
                    }
                }
            }
            return list;
        }
    }


}
