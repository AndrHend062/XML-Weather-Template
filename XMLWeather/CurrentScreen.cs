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
    public partial class CurrentScreen : UserControl
    {
        

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
           
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            currentOutput.Text = Convert.ToDouble(Form1.days[0].currentTemp).ToString("0.")+"°C";
            minOutput.Text = Convert.ToDouble(Form1.days[0].tempLow).ToString("0.") + "°C";
            maxOutput.Text = Convert.ToDouble(Form1.days[0].tempHigh).ToString("0.") + "°C";
            windlabel.Text = Convert.ToDouble(Form1.days[0].windSpeed).ToString("0.");
            windLabel2.Text = Form1.days[0].windDirection+"";

            if (Form1.days[0].condition== "800")
            {//clear sky
                conditionBox.Image = XMLWeather.Properties.Resources._01d;
            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 200 && Convert.ToInt16(Form1.days[0].condition) <299)
            {///thunderstorm  11d
                conditionBox.Image = XMLWeather.Properties.Resources._11d;

            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 300 && Convert.ToInt16(Form1.days[0].condition) < 399)
            {// drizzel   09d 
                conditionBox.Image = XMLWeather.Properties.Resources._09d;
            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 500 && Convert.ToInt16(Form1.days[0].condition) < 599)
            {//// rain 10d
                conditionBox.Image = XMLWeather.Properties.Resources._10d;
            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 600 && Convert.ToInt16(Form1.days[0].condition) < 699)
            {// snow 13d 
                conditionBox.Image = XMLWeather.Properties.Resources._13d;
            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 700 && Convert.ToInt16(Form1.days[0].condition) < 799)
            {// atmospheare 50d
                conditionBox.Image = XMLWeather.Properties.Resources._50d;
            }
            if (Convert.ToInt16(Form1.days[0].condition) >= 801 && Convert.ToInt16(Form1.days[0].condition) < 899)
            {// cloud
                conditionBox.Image = XMLWeather.Properties.Resources._03d;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
