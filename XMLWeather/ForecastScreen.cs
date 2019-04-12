using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
           // date1.Text = Form1.days[1].date;
            //date2.Text = Form1.days[2].date;
           
            #region day2
            pictureBox1.Image = Form1.GetSymbol(1);
            date1.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            min1.Text = Convert.ToDouble(Form1.days[1].tempLow).ToString("0.");
            max1.Text = Convert.ToDouble(Form1.days[1].tempHigh).ToString("0.");
            #endregion
            #region day3

            pictureBox2.Image = Form1.GetSymbol(2);
            date2.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
            min2.Text = Convert.ToDouble(Form1.days[2].tempLow).ToString("0.");
            max2.Text = Convert.ToDouble(Form1.days[2].tempHigh).ToString("0.");
            #endregion
            #region day4

            pictureBox3.Image = Form1.GetSymbol(3);
            date3.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            min3.Text = Convert.ToDouble(Form1.days[3].tempLow).ToString("0.");
            max3.Text = Convert.ToDouble(Form1.days[3].tempHigh).ToString("0.");
            #endregion
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        
            
        
    }
}
