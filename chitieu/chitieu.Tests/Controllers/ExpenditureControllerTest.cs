//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using chitieu.Controllers;
//using System.Web.Mvc;
//using chitieu.Models;
//using System.Linq;
//using System.Collections.Generic;



//namespace chitieu.Tests.Controllers
//{
//[TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestIndex()
//        {
//            var db = new expenditure();
//            var controller = new expenditureController();

//            var result = controller.Index() as ViewResult;
//            Assert.IsNotNull(result);

//            var model = result.Model as List<expenditure>;
//            Assert.IsNotNull(model);

//            Assert.AreEqual(db.Expenditures.Count(), model.Count);
//        }

//        [TestMethod]

//    public void TestDetail()
//        {
//             var controller = new ChiTieuController();
//            var result0 = controller.Edit(0);
//            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

//            var db = new QLChiTieuEntities();
//            var item = db.Expenditures.First();
//            var result1 = controller.Edit(item.id) as ViewResult;
//            Assert.IsNotNull(result1);
//            var model = result1.Model as Expenditure;
//            Assert.AreEqual(item.id, model.id);

          



//        }

//        [TestMethod]

//        public void TestCreateG()
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using QLChiTieu.Models;
//using QLChiTieu.Controllers;
//namespace QLChiTieu.Tests.Controllers
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestIndex()
//        {
//            var db = new QLChiTieuEntities();
//            var controller = new ChiTieuController();
//            var result = controller.Index() as ViewResult;
//            Assert.IsNotNull(result);
//            var model = result.Model as List<Expenditure>;

//            Assert.AreEqual(db.Expenditures.Count(),
//                (model.Count));
//        }
//         [TestMethod]
//        public void TestEditG()
//        {
//            var controller = new ChiTieuController();
//            var result0 = controller.Edit(0);
//            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

//            var db = new QLChiTieuEntities();
//            var item = db.Expenditures.First();
//            var result1 = controller.Edit(item.id) as ViewResult;
//            Assert.IsNotNull(result1);
//            var model = result1.Model as Expenditure;
//            Assert.AreEqual(item.id, model.id);

//        }
//         [TestMethod]
//         public void TestCreateG()
//         {

//             var controller = new ChiTieuController();

//             var result = controller.Create() as ViewResult;

//             Assert.IsNotNull(result);
//         }
//    }
//}

//        {
//            var controller = new expenditureController();

//            var result = controller.Create() as ViewResult;

//            Assert.IsNotNull(result);

//        }

//        [TestMethod]

//        public void TestEditG()
//        {
//            var controller = new expenditureController();
//            var result0 = controller.Edit(0);
//            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

//            var db = new expenditure();
//            var item = db.expenditure.First();
//            var result1 = controller.Edit(item.ID) as ViewResult;
//            Assert.IsNotNull(result1);
//            var model = result1.Model as expenditure;
//            Assert.AreEqual(item.ID, model.id);
//        }
//    }




//}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using chitieu.Models;
using chitieu.Controllers;
namespace QLChiTieu.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new AnchoiEntities();
            var controller = new expenditureController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as List<expenditure>;

            Assert.AreEqual(db.expenditures.Count(),
                (model.Count));
        }
        [TestMethod]
        public void TestEditG()
        {
            var controller = new expenditureController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new AnchoiEntities();
            var item = db.expenditures.First();    
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as expenditure;
            Assert.AreEqual(item.id, model.id);
            //TMMLLLLL dit me m de an choi
            
        }
        [TestMethod]
        public void TestCreateG()
        {

            var controller = new expenditureController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
