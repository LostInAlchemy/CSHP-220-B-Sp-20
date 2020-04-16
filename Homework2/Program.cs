using System;
using System.Collections.Generic;

namespace Homework2
{
    class Program
    {
        static Printer _printer = new Printer();
        static DataMod _datamod = new DataMod();

        public const string _field1 = "Name";
        public const string _field2 = "Password";
        public const string _PW = "hello";
        public const string _firstInstancePW = "hello";

        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            users.Add(new Models.User { Name = "Sam", Password = "sam" });

            _printer.Field1 = _field1;
            _printer.Field2 = _field2;

            HWQ1(users);
            Console.WriteLine("\n");
            HWQ2(users);
            Console.WriteLine("\n");
            HWQ3(users);
            Console.WriteLine("\n");
            HWQ4(users);
            Console.ReadLine();
        }

        public static void HWQ1(List<Models.User> users)
        {
            Console.WriteLine("The following users are in the database.");
            _printer.Print(users);
        }

        public static void HWQ2(List<Models.User> users)
        {
            Console.WriteLine("Print users that have '{0}' as a password.", _PW);
            _printer.Print(users, _PW);
        }

        public static void HWQ3(List<Models.User> users)
        {
            Console.WriteLine("Data manipulation");
            Console.WriteLine("Remove users where the password is the lower case version of their name.");
            users = _datamod.RemovePWLowerCaseName(users);

            Console.WriteLine("Users Removed:");
            _printer.Print(_datamod.Deletedusers);

            Console.WriteLine();

            Console.WriteLine("Users that remain:");
            _printer.Print(users);
        }

        public static void HWQ4(List<Models.User> users)
        {
            Console.WriteLine("Data manipulation");
            Console.WriteLine("Remove the first user where the password is '{0}'.", _firstInstancePW);
            users = _datamod.DeleteFirstUserByPW(users, _firstInstancePW);
            
            Console.WriteLine("User Removed:");
            _printer.Print(_datamod.Deletedusers);

            Console.WriteLine();

            Console.WriteLine("Users that remain:");
            _printer.Print(users);

        }
    }
}
