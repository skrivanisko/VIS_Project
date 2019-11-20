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
    public partial class AddConsumable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test.Text = (string)Session["ConsumableName"];
            AmountLabel.Text = new ConsumablesMapper().SelectByName(test.Text).Portion.ToString() + "g";

            if (!IsPostBack)
            {
                List<ListItem> list = new List<ListItem>();
                list.Add(new ListItem ("Breakfast", "1"));
                list.Add(new ListItem("Break", "2"));
                list.Add(new ListItem("Lunch", "3"));
                list.Add(new ListItem("Dinner", "4"));



                CategoryList.DataSource = list;
                CategoryList.DataTextField = "text";
                CategoryList.DataValueField = "value";
                CategoryList.DataBind();
            }

        }

        protected void OKButton_Click(object sender, EventArgs e)
        {
            DietPlan dp = new DietPlan();
            dp.Dpid = new DietPlanMapper().SelectMaxId()+1;
            dp.Consumable = new ConsumablesMapper().SelectByName(test.Text);
            dp.Consumables_Id = dp.Consumable.Cid;
            dp.Amount = float.Parse(AmountTextBox.Text);
            dp.Dpdate = Calendar.SelectedDate.Date;
            dp.Category = CategoryList.SelectedIndex+1;
            dp.User_Id = new UsersMapper().Select((int)Session["LoggedId"]).Userid;

            new DietPlanMapper().Insert(dp);

            Response.Redirect("DietPlanForm.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DietPlanForm.aspx");
        }
    }
}