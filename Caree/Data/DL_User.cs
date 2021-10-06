using Caree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void InsertUser(String username, String password)
        {
            var user = new User() { UserName = username, Password = password };
            Context.Users.Add(user);
            Context.SaveChanges();
        }


    }
}