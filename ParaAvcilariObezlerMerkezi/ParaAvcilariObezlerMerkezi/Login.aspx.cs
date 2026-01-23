using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParaAvcilariObezlerMerkezi
{
    public partial class Login : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_email.Text))
            {
                if (!string.IsNullOrEmpty(tb_password.Text))
                {
                    Dietitian dietitian = db.Login(tb_password.Text, tb_email.Text);
                    Session["Admin"] = dietitian;
                    if (Session["Admin"] != null)
                    {
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        throw new ArgumentException("Session Dolmadı!");
                    }
                }
            }

        }
    }
}