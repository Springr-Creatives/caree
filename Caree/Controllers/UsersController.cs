using Caree.Business;
using Caree.Entities;
using System.Web.Http;


namespace Caree.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
   
        BL_User bL_User;

        public UsersController(BL_User _bL_User)
        {
            bL_User = _bL_User;
        }


        [Route("Register")]
        public IHttpActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(bL_User.CreateUser(user));


        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bL_User.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}