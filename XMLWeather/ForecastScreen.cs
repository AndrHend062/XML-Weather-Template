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
            date1.Text = Form1.days[1].date;
            min1.Text = Convert.ToDouble(Form1.days[1].tempLow).ToString("0.");
            max1.Text = Convert.ToDouble(Form1.days[1].tempHigh).ToString("0.");

            date2.Text = Form1.days[2].date;
            min2.Text = Convert.ToDouble(Form1.days[2].tempLow).ToString("0.");
            max2.Text = Convert.ToDouble(Form1.days[2].tempHigh).ToString("0.");
            #region day2
            if (Form1.days[1].condition == "800")
            {//clear sky
                pictureBox1.Image = XMLWeather.Properties.Resources._01d;
            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 200 && Convert.ToInt16(Form1.days[1].condition) < 299)
            {///thunderstorm  11d
                pictureBox1.Image = XMLWeather.Properties.Resources._11d;

            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 300 && Convert.ToInt16(Form1.days[1].condition) < 399)
            {// drizzel   09d 
                pictureBox1.Image = XMLWeather.Properties.Resources._09d;
            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 500 && Convert.ToInt16(Form1.days[1].condition) < 599)
            {//// rain 10d
                pictureBox1.Image = XMLWeather.Properties.Resources._10d;
            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 600 && Convert.ToInt16(Form1.days[1].condition) < 699)
            {// snow 13d 
                pictureBox1.Image = XMLWeather.Properties.Resources._13d;
            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 700 && Convert.ToInt16(Form1.days[1].condition) < 799)
            {// atmospheare 50d
                pictureBox1.Image = XMLWeather.Properties.Resources._50d;
            }
            if (Convert.ToInt16(Form1.days[1].condition) >= 801 && Convert.ToInt16(Form1.days[1].condition) < 899)
            {// cloud
                pictureBox1.Image = XMLWeather.Properties.Resources._03d;
            }
            #endregion
            #region day3
            if (Form1.days[2].condition == "800")
            {//clear sky
                pictureBox2.Image = XMLWeather.Properties.Resources._01d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 200 && Convert.ToInt16(Form1.days[2].condition) < 299)
            {///thunderstorm  11d
                pictureBox2.Image = XMLWeather.Properties.Resources._11d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 300 && Convert.ToInt16(Form1.days[2].condition) < 399)
            {// drizzel   09d 
                pictureBox2.Image = XMLWeather.Properties.Resources._09d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 500 && Convert.ToInt16(Form1.days[2].condition) < 599)
            {//// rain 10d
                pictureBox2.Image = XMLWeather.Properties.Resources._10d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 600 && Convert.ToInt16(Form1.days[2].condition) < 699)
            {// snow 13d 
                pictureBox2.Image = XMLWeather.Properties.Resources._13d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 700 && Convert.ToInt16(Form1.days[2].condition) < 799)
            {// atmospheare 50d
                pictureBox2.Image = XMLWeather.Properties.Resources._50d;
            }
            if (Convert.ToInt16(Form1.days[2].condition) >= 801 && Convert.ToInt16(Form1.days[2].condition) < 899)
            {// cloud
                pictureBox2.Image = XMLWeather.Properties.Resources._03d;
            }
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
