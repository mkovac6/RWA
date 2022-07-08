using AdventureWorksManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdventureWorksManager.Forms
{
    public partial class EditBuyer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCountries();
                loadBuyer(); 
            }
            
        }

        private void loadBuyer()
        {
            var buyer = Repository.GetBuyerById(( int.Parse(Session["BuyerID"].ToString())));
            lblID.Text = $"Editing User ID: {buyer.IDKupac}";
            txtName.Text = buyer.FirstName;
            txtLastname.Text = buyer.LastName;
            txtEmail.Text = buyer.Email;
            txtPhone.Text = buyer.Phone;
            ddlCountry.SelectedValue = buyer.City.Country.IDDrzava.ToString();
            ddlCountry_SelectedIndexChanged(null, null);
            ddlCity.SelectedValue = buyer.City.IDGrad.ToString();
        }

        private void loadCountries()
        {
            ddlCountry.DataSource = Repository.GetCountries();
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "IDDrzava";
            ddlCountry.DataBind();
            
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.DataSource = Repository.GetCities().FindAll(c => c.Country.IDDrzava == int.Parse(ddlCountry.SelectedValue));
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "IDGrad";
            ddlCity.DataBind();
        }

        protected void RedirectToUsersPage(object sender, CommandEventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            Response.Redirect(page.GetRouteUrl("BuyerOverview", null));

        } protected void RedirectToRecordsPage(object sender, CommandEventArgs e)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Repository.UpdateBuyer(new Buyer
            {
                IDKupac = int.Parse(Session["BuyerID"].ToString()),
                FirstName = txtName.Text,
                LastName = txtLastname.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                City = new City { IDGrad = int.Parse(ddlCity.SelectedValue.ToString()) }
            });
        }
    }
}