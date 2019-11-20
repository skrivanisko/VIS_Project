using Data_Layer.DataMapper;
using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    
    public partial class UserActivity : Form
    {

        private Collection<string> measurementsUsersDataSourceList;
        public UserActivity()
        {
            InitializeComponent();

            measurementsUsersDataSourceList = new Collection<string>();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            foreach (User u in new UsersMapper().Select())
            {
                u.Measurements = new MeasurementsMapper().SelectUserMeas(u.Userid);
                u.DietPlans = new DietPlanMapper().SelectUserDietPlans(u.Userid);
                u.WorkoutPlans = new WorkoutPlanMapper().SelectUserWorkoutPlans(u.Userid);

                measurementsUsersDataSourceList.Add(u.GetActivityNumber());
            }

            UserActivityList.DataSource = measurementsUsersDataSourceList;
            UserActivityList.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if(measurementsUsersDataSourceList.Count() == 0)
                System.Windows.Forms.MessageBox.Show("Nothing to export!");
            else
            {
                var csv = new StringBuilder();

                var first = "Login";
                var second = "Activity Number";
                var newLine = string.Format("{0};{1}", first, second);
                csv.AppendLine(newLine);

                foreach (string s in measurementsUsersDataSourceList)
                {
                    var fr = s.Substring(0, s.IndexOf(' '));
                    var sc = s.Substring(s.IndexOf(' '), s.Length - s.IndexOf(' '));
                    var nl = string.Format("{0};{1}", fr, sc);
                    csv.AppendLine(nl);
                }

                File.WriteAllText("exports/export" + DateTime.Today.ToString("d") + "-" + Stopwatch.GetTimestamp().GetHashCode() + ".csv", csv.ToString());
            }
        }
    }
}
