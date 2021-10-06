using Caree.Business;
using Caree.Entities;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Caree.Controllers
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {

        BL_Car blCar;

        public CarsController(BL_Car _blCar)
        {
            blCar = _blCar;
        }

        // GET: api/Cars/Year/2021
        [Authorize]
        [HttpGet]
        [Route("Year/{year}")]
        public IQueryable<Car> Get(int year)
        {
            return blCar.CarsByYear(year);
        }

        // PATCH: api/Cars (JSON)
        [Authorize]
        [HttpPatch]
        [Route("")]
        public IHttpActionResult Patch([FromBody] Car car)
        {

            if (blCar.UpdateCar(car))
            {
                return StatusCode(HttpStatusCode.OK);
            }

            return StatusCode(HttpStatusCode.BadRequest);
        }

        // POST: api/Cars
        [Authorize]
        [ResponseType(typeof(Car))]
        [Route("")]
        public IHttpActionResult Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            car = blCar.CreateCar(car);
            return Ok(car);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blCar.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}