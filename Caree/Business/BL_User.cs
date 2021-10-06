using Caree.App_Start;
using Caree.Data;
using Caree.Entities;
using Newtonsoft.Json.Linq;

namespace Caree.Business
{
    public class BL_User
    {
        private DL_User dL_User = new DL_User();

        public JObject CreateUser(User user)
        {
            dL_User.InsertUser(user);
            return UserIdentityConfig.GenerateToken(user);
        }


        public void Dispose()
        {
            dL_User.Dispose();
        }
    }
}