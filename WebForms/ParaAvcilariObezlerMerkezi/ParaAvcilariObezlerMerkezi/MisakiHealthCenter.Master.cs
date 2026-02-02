using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParaAvcilariObezlerMerkezi
{
    public partial class MisakiHealthCenter : System.Web.UI.MasterPage
    {
        Database database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Dietitian dietitian = (Dietitian)Session["Admin"];
                    lbl_DietitianName.Text = "Servus! " + dietitian.Name;
                    lbl_dietitianRole.Text = dietitian.Degree;
                    if (dietitian.PhotoBinaryFormat == null)
                    {
                        img_dietitianIMG.ImageUrl = "Image/defaultuser.png";
                    }
                }
            }
        }
    }
}