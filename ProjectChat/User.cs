using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectChat
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        
        public User(List<string> s) 
        {
            Id = Convert.ToInt32(s[0]);
            Name = s[1];
            UserName = s[2];
            Password = s[3];

        }

        public  bool SendMessage(string tableName,string datebaseName,string username,  string text)
        {
            var re_id = Services.GetUsername("Users", datebaseName, username)[0];

            List<InsertModel> chat = new List<InsertModel>()
            {
                new InsertModel()
                {
                    ColumnName ="Sender",
                    Value1 = $"{Id}",
                },
                new InsertModel()
                {
                    ColumnName ="Recipient",
                    Value1 = $"{re_id}",
                },

                new InsertModel()
                {
                    ColumnName ="message_Text",
                    Value1 = text,
                },

            };
            Services.insertInto(tableName,datebaseName, chat);


            return true;
        }

        public List<List<string>> GetAllChats(string tableName, string datebaseName, string username) 
        {
            var re_id = Services.GetUsername("Users", datebaseName, username)[0];
            List<InsertModel> chat = new List<InsertModel>()
            {
                new InsertModel()
                {
                    ColumnName ="Sender",
                    Value1 = $"{Id}",
                },
                new InsertModel()
                {
                    ColumnName ="Recipient",
                    Value1 = $"{re_id}",
                },

                
            };
            return Services.GetAllChats(tableName, datebaseName, chat);
        }

       

    }
}
