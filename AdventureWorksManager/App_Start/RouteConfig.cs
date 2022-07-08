using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventureWorksManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute("LogIn", "App/Login", "~/Forms/LogIn.aspx");
            routes.MapPageRoute("Register", "App/Register", "~/Forms/Register.aspx");
            routes.MapPageRoute("BuyerOverview", "App/Overview", "~/Forms/BuyerOverview.aspx");
            routes.MapPageRoute("EditBuyer", "App/EditBuyer", "~/Forms/EditBuyer.aspx");

            routes.MapRoute(name:"Bills",
                url:"Record/{buyerId}",
                defaults: new {controller = "Record", action="GetRecord", buyerId = UrlParameter.Optional });

            routes.MapRoute(name:"BillItems",
                url: "Record/GetBillItems/{billId}",
                defaults: new {controller = "Record", action= "GetBillItems", billId = UrlParameter.Optional });

            routes.MapRoute(name:"Categories",
                url: "Record/Categories/View",
                defaults: new {controller = "Record", action= "Categories"});

            routes.MapRoute(name:"EditCategory",
                url: "Record/EditCategory/{catId}",
                defaults: new {controller = "Record", action= "EditCategory", catId = UrlParameter.Optional });

            routes.MapRoute(name:"Subcategories",
                url: "Record/Subcategories/View",
                defaults: new {controller = "Record", action= "Subcategories"});

            routes.MapRoute(name: "EditSubcategory",
                url: "Record/EditSubcategory/{subcatId}",
                defaults: new {controller = "Record", action= "EditSubcategory", subcatId = UrlParameter.Optional });

            routes.MapRoute(name: "EditProduct",
                url: "Record/EditProduct/{prodId}",
                defaults: new {controller = "Record", action= "EditProduct", prodId = UrlParameter.Optional });

            routes.MapRoute(name:"Products",
                url: "Record/Products/View",
                defaults: new {controller = "Record", action= "Products" });

            routes.MapRoute(name:"Errors",
                url: "Error/NotFound/View",
                defaults: new {controller = "Error", action= "NotFound" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
