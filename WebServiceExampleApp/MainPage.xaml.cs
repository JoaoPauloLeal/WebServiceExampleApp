using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WebServiceExampleApp.Resources;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Phone.Tasks;
using System.IO;
using System.Xml;

namespace WebServiceExampleApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


        }

        private async void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    pbWeather.Visibility = System.Windows.Visibility.Visible;
                    client.BaseAddress = new Uri("http://api.openweathermap.org");

                    var url = "data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=7";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(String.Format(url, txtPincode.Text));

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();
                        var weatherdata = JsonConvert.DeserializeObject<WeatherObject>(data.Result.ToString());

                        spWeatherInfo.DataContext = weatherdata;

                    }

                    pbWeather.Visibility = System.Windows.Visibility.Collapsed;


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("A Pagina não Pode ser Carregada!");
                pbWeather.Visibility = System.Windows.Visibility.Collapsed;
            }

        }

    }
}