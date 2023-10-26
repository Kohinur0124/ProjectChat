using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChat
{
    public class Tables
    {
        public static void CreateTables( string DatabaseName)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {

                connect.Open();
               
                string user = $"create table Users(" +
                    $"Id int identity(1,1) primary key," +
                    $"Name Varchar(100)," +
                    $"Username Varchar(100) Unique," +
                    $"password varchar(100));";

               
                string chat = $"create table Chats(" +
                    $"Id int identity(1,1) primary key," +
                    $"Sender  INT Foreign key references Users(Id)," +
                    $"Recipient INT Foreign key references Users(Id)," +
                    $"message_Text Text , " +
                    $"Date Datetime Default GetDate() );";




               // SqlCommand cmd0 = new SqlCommand(data, connect);
                SqlCommand cmd = new SqlCommand(user, connect);
               
                SqlCommand cmd2 = new SqlCommand(chat, connect);

                //cmd0.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
               
                cmd2.ExecuteNonQuery();

                Console.WriteLine("Succesfully tables created");

            }
        }
    }
}
