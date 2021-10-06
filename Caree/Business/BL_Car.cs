﻿using Caree.BL;
using Caree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caree.Business
{
    public class BL_Car : IDisposable
    {
        private DL_Car dlCar = new DL_Car();

        public IQueryable<Car> CarsByYear(int Year)
        {
            return dlCar.GetCarByYear(Year);
        }

        public Car CreateCar(Car car)
        {
            return dlCar.CreateCar(car);
        }

        public bool UpdateCar(Car car)
        {
            return dlCar.UpdateCar(car);
        }

        public void Dispose()
        {
            dlCar.Dispose();
        }

    }
}