using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Printer
    {
        private string field1;
        private string field2;

        public string Field1
        {
            get { return field1; }
            set { field1 = value; }
        }

        public string Field2
        {
            get { return field2; }
            set { field2 = value; }
        }

        public void Print(List<Models.User> users, string PW = null, string Name = null)
        {
            var databaseusers = (dynamic)null;

            Console.WriteLine("{0,0}{1,7}{2,10}", field1, "|", field2);
            Console.WriteLine("--------  |  --------");

            if (!string.IsNullOrEmpty(PW))
            {
                databaseusers = users.Cast<Models.User>()
                        .Where(u => u.Password == PW)
                        .Select(u => new { u.Name, u.Password });

                //var findHello = from u in users 
                //                where u.Password == "hello" 
                //                select new { u.Name, u.Password };
            }

            else if (!string.IsNullOrEmpty(Name))
            {
                databaseusers = users.Cast<Models.User>()
                    .Where(u => u.Name == Name)
                    .Select(u => new { u.Name, u.Password });
            }

            else
            {
                databaseusers = users.Cast<Models.User>()
                            .Select(t => new { t.Name, t.Password });

                //var databaseusers = from u in users 
                //                    select new { u.Name, u.Password };
            }

            foreach (var person in databaseusers)
            {
                Console.WriteLine("{0,-13}{1,-13}", person.Name, person.Password);
            }
        }
    }
}
