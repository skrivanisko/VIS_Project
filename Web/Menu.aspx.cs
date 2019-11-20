using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DietPlanButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DietPlanForm.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}