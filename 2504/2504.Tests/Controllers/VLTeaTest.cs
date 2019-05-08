﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2504.Controllers;
using _2504.Models;
using System.Linq;
using System.Web.Mvc;
using System.Transactions;
using System.Collections.Generic;

namespace _2504.Tests.Controllers
{
    [TestClass]
    public class VLTeaTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new VLTeaController();
            var result = controller.Index();

            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as List<Buble>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);

        }

    [TestMethod]
        public void TestCreateG()
        {
            var controller = new VLTeaController();
            var result = controller.create();

            var view = result as ViewResult;
            Assert.IsNotNull(view);

        }
        
        [TestMethod]
        public void testCreateP()
    {
            var model = new BubleTea
            {
                Name = "Hoa huong duong",
                Topping = "tran chau, banh flan",
                Price = 0
            };
            var db = new CS4PEEntities();
            var controller = new VLTeaController();

            using (var scope = new TransactionScope()){
                var result = controller.create(model);
                var view = result as ViewResult;
                Assert.IsNotNull(view);
                Assert.IsInstanceOfType(view.Model, typeof(BubleTea));
                Assert.AreEqual(Resource1.PRICE_LESS_0, controller.ViewData.ModelState["Price"].Errors[0].ErrorMessage);

                model.Price = 26000;
                controller = new VLTeaController();
                result = controller.create(model);
                var redirect = result as RedirectToRouteResult;
                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);
                var item = db.BubleTeas.Find(model.id);
                Assert.IsNotNull(item);
                Assert.AreEqual(model.Name, item.Name);
                Assert.AreEqual(model.Topping, item.Topping);
                Assert.AreEqual(model.Price, item.Price);
            
            }

          
          }
        [TestMethod]
        public void TestDelete()
        {
            var db = new CS4PEEntities();
            var controller = new VLTeaController();

            var result = controller.Delete(0);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            using (var scope = new TransactionScope())
            {
                var model = db.BubleTeas.AsNoTracking().First();
                result = controller.Delete(model.id);
                var redirect = result as RedirectToRouteResult;
                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);
                var item = db.BubleTeas.Find(model.id);
                Assert.IsNull(item);
            }
            

        }
        [TestMethod]
        public void TestEditG()
        {
            var db = new CS4PEEntities();
            var controller = new VLTeaController();
            var result = controller.Edit(0);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            var item = db.BubleTeas.First();
            result = controller.Edit(item.id);
            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
            Assert.AreEqual(item.Name, model.Name);
            Assert.AreEqual(item.Topping, model.Topping);
            Assert.AreEqual(item.Price, model.Price);
           

        }
        public void TestEditP()
        {
            var db = new CS4PEEntities();
            var model = new BubleTea
            {
                id = db.BubleTeas.AsNoTracking().First().id,
                Name = "Hoa Hướng Dương",
                Topping = "Trân Châu, Bánh Flan",
                Price = 0
            };


            var controller = new VLTeaController();

            using (var scope = new TransactionScope())
            {
                var result = controller.Edit(model);
                var view = result as ViewResult;
                Assert.IsNotNull(view);
                Assert.IsInstanceOfType(view.Model, typeof(BubleTea));
                Assert.AreEqual(Resource1.PRICE_LESS_0, controller.ViewData.ModelState["Price"].Errors[0].ErrorMessage);

                model.Price = 26000;
                controller = new VLTeaController();
                result = controller.create(model);
                var redirect = result as RedirectToRouteResult;
                Assert.IsNotNull(redirect);
                Assert.AreEqual("Index", redirect.RouteValues["action"]);
                var item = db.BubleTeas.Find(model.id);
                Assert.IsNotNull(item);
                Assert.AreEqual(model.Name, item.Name);
                Assert.AreEqual(model.Topping, item.Topping);
                Assert.AreEqual(model.Price, item.Price);
            }
        }
        
     }
}
