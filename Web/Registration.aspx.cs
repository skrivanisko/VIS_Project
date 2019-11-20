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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FinishRegistrationButton_Click(object sender, EventArgs e)
        {
            if(LoginText.Text!=null && NameText.Text!=null && SurnameText.Text!=null &&
                PassText.Text != null && BirthText.Text != null && EmailText.Text!=null)
            {
                

                User u = new User();
                u.Userid = new UsersMapper().SelectNextFreeID();
                u.Name = NameText.Text;
                u.Surname = SurnameText.Text;
                u.Login = LoginText.Text;
                u.Password = PassText.Text;
                u.Birthday = DateTime.Parse(BirthText.Text);
                u.Email = EmailText.Text;
                u.Admin = 0;

                if(new UsersMapper().Insert(u)==1)
                    Response.Write("<script language=javascript>alert('Úspěšná registrace!')</script>");



            } else Response.Write("<script language=javascript>alert('Některá pole nejsou vyplněna')</script>");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}