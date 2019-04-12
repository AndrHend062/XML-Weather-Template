using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // : create list to hold day objects
        public static List<Day> days = new List<Day>();

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();

            // open weather screen for todays weather
             CurrentScreen cs = new CurrentScreen();
           // ForecastScreen fs = new ForecastScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {

                //: create a day object
                Day d = new Day();
                //: fill day object with required data
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

               
                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("number");
   
                reader.ReadToFollowing("windDirection");
                d.windDirection = reader.GetAttribute("code");
                reader.ReadToFollowing("windSpeed");
                d.windSpeed = reader.GetAttribute("mps");

                reader.ReadToFollowing("temperature");
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");
                //TODO: if day object not null add to the days list
                if (d != null)
                {
                    days.Add(d);
                }
            }
            reader.Close();
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");
            days[0].tempLow = reader.GetAttribute("max");
            days[0].tempHigh = reader.GetAttribute("min");

            reader.ReadToFollowing("humidity");
            days[0].humidity = reader.GetAttribute("value");

            reader.ReadToFollowing("weather");
            days[0].condition = reader.GetAttribute("number");

            

        }
        public static Image GetSymbol(int d)
        {
            if (Form1.days[d].condition == "800")
            {//clear sky
                return Properties.Resources._01d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 200 && Convert.ToInt16(Form1.days[d].condition) < 299)
            {///thunderstorm  11d
                return Properties.Resources._11d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 300 && Convert.ToInt16(Form1.days[d].condition) < 399)
            {// drizzel   09d 
                return Properties.Resources._09d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 500 && Convert.ToInt16(Form1.days[d].condition) < 599)
            {//// rain 10d
                return Properties.Resources._10d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 600 && Convert.ToInt16(Form1.days[d].condition) < 699)
            {// snow 13d 
                return Properties.Resources._13d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 700 && Convert.ToInt16(Form1.days[d].condition) < 799)
            {// atmospheare 50d
                return Properties.Resources._50d;
            }
            if (Convert.ToInt16(Form1.days[d].condition) >= 801 && Convert.ToInt16(Form1.days[d].condition) < 899)
            {// cloud
                return Properties.Resources._03d;
            }
            else
            {
                return Properties.Resources._01d;
            }

        }

    }
}
