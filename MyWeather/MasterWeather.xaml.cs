using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterWeather : Page
    {
        public MasterWeather()
        {
            this.InitializeComponent();
            
        }

      
            private async void GetWeather_Click(object sender, RoutedEventArgs e)
            {
            
              
            string Lat, Lan;
                ProgressRing.IsActive = true;

            /*var geoLocator = new Geolocator();

            geoLocator.DesiredAccuracy = PositionAccuracy.High;




            Geoposition pos = await geoLocator.GetGeopositionAsync();
            */
            var pos = await LocationManager.GetPosition();

            Lat = pos.Coordinate.Point.Position.Latitude.ToString();
                Lan = pos.Coordinate.Point.Position.Longitude.ToString();

                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(Lat, Lan);

                

            

                City.Text = myWeather.name + " ," + myWeather.sys.country;
                Today.Text = "Today is: " + DateTime.Now.ToString("dd/MM/yyyy");
                LocalTime.Text = "Last updated: " + DateTime.Now.ToString("HH:mm:ss");

                //string icon = String.Format("http://openweathermap.org/img/wn/{0}.png", myWeather.weather[0].icon);
                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            
            Description.Text = myWeather.weather[0].description;
            Temperature.Text = "Temperature is: " + myWeather.main.temp + " °C"; 
            FeelsLike.Text = "Feels like is: " + myWeather.main.feels_like + " °C";
            Humidity.Text = "Humidity: " + myWeather.main.humidity;
           


            ProgressRing.IsActive = false;
          
           
            
            }
        
    }
}
