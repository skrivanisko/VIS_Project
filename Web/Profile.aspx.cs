using Data_Layer.DataMapper;
using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Profile : System.Web.UI.Page
    {
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            u = new UsersMapper().Select((int)Session["LoggedId"]);

            u.Measurements = new MeasurementsMapper().SelectUserMeas(u.Userid);

            BMIText.Text = u.GetBMI();
            NameText.Text = u.Name + " " + u.Surname;
            LoginText.Text = u.Login;
            EmailText.Text = u.Email;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}