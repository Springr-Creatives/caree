using Caree.Entities;
using System;
using System.Linq;

namespace Caree.Data
{
    public class DL_User
    {
        private CarDbContext Context;

        public DL_User()
        {
            Context = new CarDbContext();
        }

        public bool ValidateUser(String username, String password)
        {
            var user = from c in Context.Users
                       where (c.UserName == username && c.Password == password)
                       select c;

            if (user.Count() != 0)
            {
                return true;
            }

            return false;
        }

        public User InsertUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return user;
        }


        public void Dispose()
        {

            Context.Dispose();

        }


    }
}