using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
            MyFrame.Navigate(typeof(Home));
            Home.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                MyFrame.Navigate(typeof(Home));
                BackButton.Visibility = Visibility.Collapsed;
                Home.IsSelected = true;
            }
            else if (Weather.IsSelected)
            {
                MyFrame.Navigate(typeof(MasterWeather));
                BackButton.Visibility = Visibility.Visible;
                Weather.IsSelected = true;
            }
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                MyFrame.Navigate(typeof(Home));
                BackButton.Visibility = Visibility.Collapsed;
                Home.IsSelected = true;
            }
        }


        /* private async void Button_Click(object sender, RoutedEventArgs e)
         {
              string Lat, Lan;
              ProgressRing.IsActive = true;

              var geoLocator = new Geolocator();
              geoLocator.DesiredAccuracy = PositionAccuracy.High;

              Geoposition pos =  await geoLocator.GetGeopositionAsync();

              Lat = pos.Coordinate.Point.Position.Latitude.ToString();
              Lan = pos.Coordinate.Point.Position.Longitude.ToString();

             RootObject myWeather = await OpenWeatherMapProxy.GetWeather(Lat, Lan);




             City.Text = myWeather.name + " ," + myWeather.sys.country;
             Today.Text = "Today is: " + DateTime.Now.ToString("dd/MM/yyyy");
             LocalTime.Text = "Last updated: " + DateTime.Now.ToString("HH:mm:ss");

              //string icon = String.Format("http://openweathermap.org/img/wn/{0}.png", myWeather.weather[0].icon);
              string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
              ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

              Temperature.Text = "Temperature is: " + myWeather.main.temp + " °C and " + "Feels like is: " + myWeather.main.feels_like + " °C";
              Description.Text = myWeather.weather[0].description;

              ProgressRing.IsActive = false;
         }
        */
    }
}
