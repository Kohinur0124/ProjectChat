// See https://aka.ms/new-console-template for more information
using ProjectChat;
using Sharprompt;

Console.WriteLine("Hello, World!");

string databaseName = "ConsoleChat";
string tablename = "Users";
string tablename1 = "Chats";
/*
List<InsertModel> user = new List<InsertModel>()
{
    new InsertModel()
    {
        ColumnName ="Name",
        Value1 = "Sevinch",
    },
    new InsertModel()
    {
        ColumnName ="Username",
        Value1 = "Nur_0124",
    },
    
    new InsertModel()
    {
        ColumnName ="password",
        Value1 = "Nur_0124"
    }
    *//*
    new InsertModel()
    {
        ColumnName ="phone_number",
        Value1 = "+998998302616"
    },
    new InsertModel()
    {
        ColumnName ="password",
        Value1 = "Sadaf"
    },*//*
};


List<InsertModel> user1 = new List<InsertModel>()
{
    new InsertModel()
    {
        ColumnName ="Name",
        Value1 = "Sadaf",
    },
    new InsertModel()
    {
        ColumnName ="Username",
        Value1 = "S_0124",
    },

    new InsertModel()
    {
        ColumnName ="password",
        Value1 = "S_0124"
    }
    *//*
    new InsertModel()
    {
        ColumnName ="phone_number",
        Value1 = "+998998302616"
    },
    new InsertModel()
    {
        ColumnName ="password",
        Value1 = "Sadaf"
    },*//*
};*/

while (true)
{
    var choice = Prompt.Select("", new[] { "Kirish", "Ro`yhatdan o`tish", "Exit" });

    if(choice == "Kirish")
    {
        Console.WriteLine("Username :");
        string user_name = Console.ReadLine();
        List<string> pass = Services.GetUsername(tablename, databaseName, user_name);
        if(pass != null)
        {

            Console.WriteLine("Password :");
        
            string passw = Console.ReadLine();
            if (passw.Equals(pass[3]))
            {
                while (true)
                {
                    var user = new User(pass);
                    var user1id = Prompt.Select("", Services.GetAll(tablename, databaseName).Select(x => x[2]).ToList());
                    var chat = Prompt.Select("", new[] { "Xabarlarni ko`rish", "Xabar yuborish", "Exit" });
                    if(chat == "Xabarlarni ko`rish")
                    {
                        user.GetAllChats(tablename1, databaseName, user1id).Select(x => Services.GetUsernameById(tablename, databaseName, x[1]) + " :  " + x[3] + "  :" + x[4]).
                            ToList().ForEach(x=> Console.WriteLine("\t"+x));

                    }
                    else if(chat == "Xabar yuborish")
                    {
                        Console.WriteLine("Xabar kiriting");
                        string s = Console.ReadLine();
                        if (user.SendMessage(tablename1, databaseName, user1id, s))
                        {
                            Console.WriteLine("Xabar yuborildi");
                        }
                        else
                        {
                            Console.WriteLine("Xabar yuborilmadi");
                        }

                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Parol noto`gri kiritilgan !!!");
                continue;
            }

        }
        else
        {
            Console.WriteLine("Username topilmadi !!!");
            continue;
        }


    }
    
    else if(choice =="Ro`yhatdan o`tish")
    {
        Console.WriteLine("Ismingizni kiriting");
        string name = Console.ReadLine();
        Console.WriteLine("Username kiriting");
        string newUsername = Console.ReadLine();
        if (Services.CheckUsername(tablename, databaseName, newUsername))
        {
            Console.WriteLine("Parol kiriting");
            string p = Console.ReadLine();
            List<InsertModel> user = new List<InsertModel>()
            {
                new InsertModel()
                {
                    ColumnName ="Name",
                    Value1 = name,
                },
                new InsertModel()
                {
                    ColumnName ="Username",
                    Value1 = newUsername,
                },
                new InsertModel()
                {
                    ColumnName ="password",
                    Value1 = p
                }
                
            };
            if (Services.Register(tablename, databaseName, user))
            {
                Console.WriteLine("Royhatdan o`tdingiz !!!");
            }
            else
            {
                Console.WriteLine("Ro`yhatdan o`tishda xatolik !!!");
            }


        }
        else
        {
            Console.WriteLine("Bunday Username band");
        }

    }
    else
    {
        return 0;
    }
}







//Console.WriteLine(Services.Register(tablename ,databaseName,user1));
//var user11 = Services.GetUsername(tablename, databaseName, "Nur_0124");
//var u1 = new User(user11);
//u1.GetAllChats(tablename1, databaseName, "S_0124").Select(x => Services.GetUsernameById(tablename, databaseName, x[1]) +" :  "+x[3]+ "  :" + x[4]).ToList().ForEach(Console.WriteLine);
//Tables.CreateTables(databaseName);

