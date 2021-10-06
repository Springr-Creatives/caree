using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Caree.BL;
using Caree.Data;
using Caree.Entities;

namespace Caree.Controllers
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {

        private CarBL carBL = new CarBL();

        // GET: api/Cars/Year/2021
        [HttpGet]
        [Route("Year/{year}")]
        public IQueryable<Car> Get(int year)
        {
            return carBL.GetCarByYear(year);
        }

        // PATCH: api/Cars (JSON)
        [HttpPatch]
        [Route("")]
        public IHttpActionResult Patch([FromBody] Car car)
        {

            if (carBL.UpdateCar(car))
            {
                return StatusCode(HttpStatusCode.OK);
            }

            return StatusCode(HttpStatusCode.BadRequest);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        [Route("")]
        public IHttpActionResult Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            car = carBL.CreateCar(car);
            return Ok(car);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                carBL.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}