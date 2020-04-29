using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class UserDatabase
    {
        public IEnumerable Users { get; internal set; }

        public UserDatabase()
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });
            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            //users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            Users = users;
        }
    }
}
