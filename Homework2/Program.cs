using System;
using System.Collections.Generic;

namespace Homework2
{
    class Program
    {
        private Models.User user = new Models.User();
        static Printer printer = new Printer();
        static DataMod datamod = new DataMod();



        static void Main(string[] args)
        {

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            printer.PasswordHello(users);

            printer.Print(users);



      

            foreach(Models.User datamodUser in datamod.RemovePWLowerCaseName(users))
            {
                foreach (Models.User user in users)
                {
                    if (datamodUser.Name == user.Name)
                    {
                        if (datamodUser.Password == user.Password)
                        {
                            //users.Remove(users[i].Password);
                            users.Remove(datamodUser);
                        }
                    }
                }
                
            }

            printer.Print(users);









            Console.ReadLine();
        }
    }
}
