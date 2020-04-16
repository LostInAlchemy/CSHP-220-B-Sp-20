using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class DataMod
    {
        public List<Models.User> Deletedusers;

        public List<Models.User> RemovePWLowerCaseName(List<Models.User> users)
        {
            Deletedusers = new List<Models.User>(users);
            Deleted("lower");

            users.RemoveAll(u => u.Name.ToLower() == u.Password);

            return users;
        }

        public List<Models.User> DeleteFirstUserByPW(List<Models.User> users, string PW)
        {
            //Deletedusers.Clear();
            Deletedusers = new List<Models.User>(users);
            Deleted("first", PW);

            users.Remove(users.Where(u => u.Password == PW).FirstOrDefault());

            return users;
        }

        public void Deleted(string choice, string PW = null)
        {
            var databaseusers = (dynamic)null;

            switch (choice)
            {
                case "lower":
                    Deletedusers.RemoveAll(deletedu => deletedu.Name.ToLower() != deletedu.Password);
                    break;

                case "first":
                    databaseusers = Deletedusers
                        .Where(u => u.Password == PW)
                        .Select(u => new { u.Name, u.Password })
                        .FirstOrDefault();

                    Deletedusers.Clear();

                    Deletedusers.Add(new Models.User { Name = databaseusers.Name, Password = databaseusers.Password });
                    break;
            }


        }
    }
}
