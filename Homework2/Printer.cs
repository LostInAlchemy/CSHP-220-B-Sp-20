using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    class Printer
    {
        public void PasswordHello(List<Models.User> users)
        {
            //var findHello = users.Cast<Models.User>().Where(t => t.Password == "hello")
            //    .Select(t => t.Name);

            //foreach (string person in findHello)
            //{
            //    Console.WriteLine(person);
            //}

            var findHello = from u in users where u.Password == "hello" select new { u.Name, u.Password };

            foreach (var person in findHello)
            {
                Console.WriteLine("{0}\t{1}", person.Name, person.Password);
            }
        }

        public void Print(List<Models.User> users)
        {
            //users.Cast<Models.User>().Select(t => new { t.Name, t.Password });

            var databaseusers = from u in users select new { u.Name, u.Password };

            foreach (var person in databaseusers)
            {
                Console.WriteLine("{0}\t{1}", person.Name, person.Password);
            }
        }
    }
}
