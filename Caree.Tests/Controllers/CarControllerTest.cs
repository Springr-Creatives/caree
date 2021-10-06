using Caree.BL;
using Caree.Business;
using Caree.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Web.Http;

namespace Caree.Tests.Controllers
{
    [TestClass]
    public class TestCarsController
    {
        private Mock<BL_Car> _bl_Car;

		protected TestCarsController(DbContextOptions<ItemsContext> contextOptions)
		{
			ContextOptions = contextOptions;

			Seed();
		}

		protected DbContextOptions<ItemsContext> ContextOptions { get; }

		private void Seed()
		{
			using (var context = new ItemsContext(ContextOptions))
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

				var one = new Item("ItemOne");
				one.AddTag("Tag11");
				one.AddTag("Tag12");
				one.AddTag("Tag13");

				var two = new Item("ItemTwo");

				var three = new Item("ItemThree");
				three.AddTag("Tag31");
				three.AddTag("Tag31");
				three.AddTag("Tag31");
				three.AddTag("Tag32");
				three.AddTag("Tag32");

				context.AddRange(one, two, three);

				context.SaveChanges();
			}
		}

		[TestInitialize]
        public void SetUp()
        {
            _bl_Car = new Mock<BL_Car>();
        }

        [TestMethod]
        public void GetReturnsCar()
        {

            var controller = new CarsController(new BL_Car(new DL_Car()));

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();


            var response = controller.Get(2021);
            System.Diagnostics.Debug.WriteLine(response);
            //   Assert.IsTrue(response.TryGetContentValue<Car>(out cars));
            // Assert.AreEqual(10, product.Id);
        }
    }
}
