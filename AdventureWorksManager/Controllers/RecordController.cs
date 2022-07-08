using AdventureWorksManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksManager.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRecord(string buyerId)
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }
            List<Bill> bills = Repository.GetBuyerRecords(buyerId);
            ViewBag.buyer = Repository.GetBuyerById(int.Parse(buyerId));

            return View(bills);
        }

        public ActionResult GetBillItems(string billId)
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            ViewBag.bill = Repository.GetBillById(int.Parse(billId));

            
            List<BillItem> billItems = Repository.GetBillItems(int.Parse(billId));

            return View(billItems);
        }

        [HandleError]
      
      
        public ActionResult Categories()
        {

            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var cat = Repository.GetCategories();
           
            return View(cat);
        }

      
        [HttpPost]
        public ActionResult Categories(string catInfo, int action)
        {
            if (action == 0)
            {
            Repository.DeleteCategory(catInfo.ToString());
            }
            else
            {
                Repository.AddCategory(catInfo.ToString());
            }

            var cat = Repository.GetCategories();
            return View(cat);
        }

        [HttpGet]

        public ActionResult Subcategories()
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var subcat = Repository.GetSubcategories();

            var categories = Repository.GetCategories();

            ViewBag.cats = categories;

            return View(subcat);
        }

        [HttpPost]
        public ActionResult Subcategories(int subcatId, string name)
        {
            if (name == "")
            {
                Repository.DeleteSubcategory(subcatId); 
            }
            else
            {
                Repository.AddSubcategory(subcatId, name);
            }

            var subcat = Repository.GetSubcategories();
            var categories = Repository.GetCategories();

            ViewBag.cats = categories;

            return View(subcat);
        }

        [HttpGet]

        public ActionResult Products()
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var products = Repository.GetProducts();

            var subcats = Repository.GetSubcategories();

            ViewBag.subcats = subcats;

            return View(products);
        }
        [HttpPost]

        public ActionResult Products(string prodInfo)
        {


            var lines = prodInfo.Split('|');
            if (lines.Length == 1)
            {
                Repository.DeleteProduct(int.Parse(lines[0]));
            }
            else
            {
                Repository.AddProduct(lines[0], lines[2], lines[1], lines[4], lines[3], lines[5]);
            }
            var products = Repository.GetProducts();

            var subcats = Repository.GetSubcategories();

            ViewBag.subcats = subcats;

            return View(products);
        }

        [HttpGet]
        public ActionResult EditCategory(int catId)
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var category = Repository.GetCategory(catId);

            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(int catId, string name)
        {
            Repository.EditCategory(catId, name);
            var category = Repository.GetCategory(catId);

            return View(category);
        }
        [HttpGet]
        public ActionResult EditSubcategory(int subcatId)
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var subcat = Repository.GetSubcategory(subcatId);



            ViewBag.list = new SelectList(Repository.GetCategories(),"ID","Name",subcat.Category.ID);

            return View(subcat);
        }

        [HttpPost]
        public ActionResult EditSubcategory(int subcatId, string name, int catId)
        {
            
            Repository.EditSubcategory(subcatId, name, catId);

            var subcat = Repository.GetSubcategory(subcatId);
            ViewBag.list = new SelectList(Repository.GetCategories(), "ID", "Name", subcat.Category.ID);

            return View(subcat);
        }

        [HttpGet]

        public ActionResult EditProduct(int prodId)
        {
            if (!Authentication.CheckLoginStatus())
            {
                return RedirectToRoute("LogIn", null);
            }

            var product = Repository.GetProductById(prodId);

            ViewBag.list = new SelectList(Repository.GetSubcategories(), "ID", "Name", product.Subcategory.ID);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(int prodId, string prodInfo)
        {
            var lines = prodInfo.Split('|');
            Repository.EditProduct(prodId, lines[0], lines[1], lines[2], lines[3], lines[4], int.Parse(lines[5]));
               

            var product = Repository.GetProductById(prodId);

            ViewBag.list = new SelectList(Repository.GetSubcategories(), "ID", "Name", product.Subcategory.ID);

            return View(product);
        }

        [HandleError]
        public ActionResult RecordError()
        {
            return View();
        }

    }

    
}