using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2504.Controllers;
using _2504.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;


namespace _2504.Tests.Controllers
{
    [TestClass]
    public class bubleteatest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new bubleteaController();
            var result = controller.Index();

            var view = result as ViewResult;
            Assert.IsNotNull(view);

            var model = view.Model as List<BubleTea>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);

        }
        [TestMethod]
        public void TestEditG()
        {
            var controller = new bubleteaController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.AreEqual(item.id, model.id);


        }








        [TestMethod]
        public void testCreateP()
        {
            var db = new CS4PEEntities();
            var model = new BubleTea
            {
                Name = "tra sua vl",
                Price = 25000,
                Topping = "Trang chau trang"
            };
            var controller = new bubleteaController();

            var result = controller.Create(model);
            var redirect = result as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
            var item = db.BubleTeas.Find(model.id);
            Assert.IsNotNull(item);
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
        }

    }
}
