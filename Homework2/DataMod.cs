using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    class DataMod
    {
        public List<Models.User> RemovePWLowerCaseName(List<Models.User> users)
        {
            List<Models.User> users1 = new List<Models.User>();

            var PWofUserName = from u in users
                               where u.Name.ToLower() == u.Password
                               select new { u.Name, u.Password };


            //var PWofUserName = users.Where(u => u.Name.ToLower() == u.Password);//.Select( new { u.Name, u.Password });

            foreach (var u in PWofUserName)
            {
                users1.Add(new Models.User { Name = u.Name, Password = u.Password });
            }


            //return (List < Models.User >)PWofUserName;
            return users1;
        }

        public void FirstHello(List<Models.User> users)
        {

        }
    }
}
