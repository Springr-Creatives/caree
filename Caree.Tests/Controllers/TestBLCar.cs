using Caree.BL;
using Caree.Business;
using Caree.Data;
using Caree.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Caree.Tests.Controllers
{
    [TestClass]
    public class TestBLCar
    {


        [TestMethod]
        public void Test_Return_Car_By_Year()
        {
            //Arrange
            var data = new List<Car>
            {
                 new Car {CarId = 1, Name= "Volkswagen", Color= "Black", YearMade= 2021 },
                  new Car {CarId = 1, Name= "Ferrari", Color= "Red", YearMade= 2021 },
                 new Car {CarId = 1, Name= "Skoda", Color= "White", YearMade= 2020 }

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Car>>();
            mockSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CarDbContext>();
            mockContext.Setup(m => m.Cars).Returns(mockSet.Object);


            //Act
            var bl_Car = new BL_Car(new DL_Car(mockContext.Object));
            var NewCars = bl_Car.CarsByYear(2021);

            //Assert
            Assert.AreEqual(NewCars.Count(), 2);
            foreach (var NewCar in NewCars)
            {
                Assert.AreEqual(NewCar.YearMade, 2021);
            }


        }
    }
}
