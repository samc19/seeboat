using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace MapApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        async void GenerateMapAroundLocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(0.1));
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.1)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var pin = new Pin()
            {
                Position = new Position(position.Latitude + 0.001, position.Longitude + 0.001),
                Label = "Click this text to see charts!",
                
            };
            map.Pins.Add(pin);
            

            pin.Clicked += goToChart;
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }

        async void goToChart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs());

        }

        private void GetMap_Clicked(object sender, EventArgs e)
        {
            GenerateMapAroundLocation();

        }
    }
	}

