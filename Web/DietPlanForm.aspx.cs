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
    public partial class DietPlanForm : System.Web.UI.Page
    {
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["LoggedId"];
            u = new UsersMapper().Select(id);

            if (!IsPostBack)
            {
                ConsumablesChoice.DataSource = new ConsumablesMapper().Select();
                ConsumablesChoice.DataValueField = "Cid";
                ConsumablesChoice.DataTextField = "Name";
                ConsumablesChoice.DataBind();

                u.DietPlans = new DietPlanMapper().SelectUserDietPlans(u.Userid, DateTime.Today.Date); //today

                DietPlan.DataSource = u.DietPlans;
                //DietPlan.DataValueField = "Value";
                DietPlan.DataValueField = "Dpid";
                DietPlan.DataTextField = "Showcase";
                Macros.Text = u.UserMakros();
                DietPlan.DataBind();
            }

            

        }

        public void UpdatePlan()
        {
            u.DietPlans = new DietPlanMapper().SelectUserDietPlans(u.Userid, Calendar.SelectedDate.Date);

            DietPlan.DataSource = u.DietPlans;
            DietPlan.DataValueField = "Dpid";
            DietPlan.DataTextField = "Showcase";
            Macros.Text = u.UserMakros();
            DietPlan.DataBind();
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            UpdatePlan();
        }

        protected void PercentageButton_Click(object sender, EventArgs e)
        {
            UpdatePlan();
            Macros.Text = u.UserMakrosPercentage();
        }

        protected void UpdateMacros_Click(object sender, EventArgs e)
        {
            UpdatePlan();
        }

        protected void SelectConsumableButton_Click(object sender, EventArgs e)
        {
            Session["ConsumableName"] = ConsumablesChoice.SelectedItem.Text;
                Response.Redirect("AddConsumable.aspx");
            
        }

        protected void ConsumablesChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ignore
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DietPlan.SelectedItem != null)
            {
                new DietPlanMapper().Delete((int.Parse(DietPlan.SelectedItem.Value)));
                UpdatePlan();
            }
                
        }

        protected void DetailButton_Click(object sender, EventArgs e)
        {
            if(DietPlan.SelectedItem!=null)
            {
                Consumable c = new ConsumablesMapper().Select(new DietPlanMapper().Select(int.Parse(DietPlan.SelectedItem.Value)).Consumables_Id);

                Response.Write("<script language=javascript>alert('" + c.ToString() + "')</script>");
            }
            
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}