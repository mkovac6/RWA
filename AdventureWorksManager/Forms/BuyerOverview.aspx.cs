using AdventureWorksManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdventureWorksManager.Forms
{
    public partial class BuyerOverview : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Authentication.CheckLoginStatus())
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
            BindListItems(Repository.GetBuyers());
            BindCountries();
            }           

        }

        private void BindCountries()
        {
            ddlCountry.DataSource = Repository.GetCountries();
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "IDDrzava";
            ddlCountry.DataBind();
            BindCities(ddlCountry.SelectedValue);
        }

        private void BindCities(string selectedValue)
        {
            ddlCity.DataSource = Repository.GetCities().FindAll(c => c.Country.IDDrzava == int.Parse(selectedValue));
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "IDGrad";
            ddlCity.ClearSelection();
            ddlCity.DataBind();
        }

        private void BindListItems(List<Buyer> buyers)
        {
            int NumberOfSelections = Session["NumSelections"] == null ? 25 : (int)Session["NumSelections"];
            bool SortByName = Session["SortParameter"] == null ? true : (bool)Session["SortParameter"]; ;
            Session["previousList"] = buyers;
        List<BuyerDisplay> bd = new List<BuyerDisplay>();
            buyers.ForEach(b => bd.Add(new BuyerDisplay {IDKupac = b.IDKupac, 
                FirstName = b.FirstName, LastName=b.LastName, Email = b.Email, Phone=b.Phone, City = b.City, Country = b.City.Country }));

            dgBuyers.DataSource = SortByName? bd.Take(NumberOfSelections).OrderBy(b => b.FirstName) : bd.Take(NumberOfSelections).OrderBy(b => b.LastName);
            dgBuyers.DataBind();

            

        }

        protected void RedirectToEditPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Session["BuyerID"] = e.CommandArgument;
            //Response.Redirect("EditBuyer.aspx");
            Response.Redirect(page.GetRouteUrl("EditBuyer", null));
        }
        protected void RedirectToRecordsPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("Bills", new { buyerId = e.CommandArgument }));
           
        }
        protected void RedirectToCategoriesPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("Categories", null));
           
        }
        protected void RedirectToSubcategoriesPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("Subcategories", null));
           
        }
        protected void RedirectToProductsPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("Products", null));
           
        }


        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCities(ddlCountry.SelectedValue);
            var a = Repository.GetBuyers().Where(b => b.City.Country.IDDrzava == int.Parse(ddlCountry.SelectedValue)).ToList();
            BindListItems(a);
            ddlCity.ClearSelection();
           
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            BindListItems(Repository.GetBuyers().FindAll( b => b.City.IDGrad == int.Parse(ddlCity.SelectedValue)));
            
        }

        protected void SetListLength(object sender, CommandEventArgs e)
        {
            Session["NumSelections"] = int.Parse(e.CommandArgument.ToString());
            var a = (List<Buyer>)Session["previousList"];
            BindListItems(a);
        }

        protected void SetSortParameter(object sender, CommandEventArgs e)
        {
            Session["SortParameter"] = Boolean.Parse(e.CommandArgument.ToString());
            var a = (List<Buyer>)Session["previousList"];
            BindListItems(a);
        }
    }
}