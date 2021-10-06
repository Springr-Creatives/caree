using Caree.Data;
using Caree.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Caree.BL
{
    public class DL_Car : IDisposable
    {
        private CarDbContext Context;

        public DL_Car(CarDbContext _carDbContext)
        {
            Context = _carDbContext;
        }

        public DL_Car()
        {
            Context = new CarDbContext();
        }

        public Car CreateCar(Car car)
        {
            Context.Cars.Add(car);
            Context.SaveChanges();
            return car;
        }

        public bool UpdateCar(Car car)
        {
            Context.Entry(car).State = EntityState.Modified;
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;

            }
        }

        public IQueryable<Car> GetCarByYear(int year)
        {
            return Context.Cars.Where(c => c.YearMade == year);
        }



        public void Dispose()
        {

            Context.Dispose();

        }
    }
}