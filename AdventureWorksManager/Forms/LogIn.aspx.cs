using AdventureWorksManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdventureWorksManager.Views
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginSubmit(object sender, EventArgs e)
        {
            lblResult.Text = "";
            try
            {
                Models.Login l = Repository.CheckLogin(txtEmail.Text, txtPassword.Text);
                Session["Login"] = l;
                Response.Redirect("BuyerOverview.aspx");
            }
            catch (Exception ex)
            {

                lblResult.Text = ex.Message;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}