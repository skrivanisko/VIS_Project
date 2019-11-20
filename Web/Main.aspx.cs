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
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //TODO: properties solutiony vybrat web app
        {
            logo.ImageUrl = "https://www.frenchlick.com/sites/default/files/Fitness%20Icon_15.png";
            LoginButton.ImageUrl = "https://image.flaticon.com/icons/png/128/494/494940.png";
            RegistrationButton.ImageUrl = "https://img.icons8.com/wired/2x/note.png";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            User u = new UsersMapper().FindUserByLogin(LoginTextBox.Text);

            if (u != null)
            {
                if (PasswordTextBox.Text == u.Password)
                {
                    Session["LoggedId"] = u.Userid;
                    Response.Redirect("Menu.aspx");
                }
                else Response.Write("<script language=javascript>alert('Wrong password!')</script>");
            }
            else Response.Write("<script language=javascript>alert('User not found!')</script>");
        }

        protected void RegistrationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}