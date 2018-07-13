using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;


namespace MapApp
{
    public class MapPage : ContentPage
    {
        Plugin.Geolocator.Abstractions.Position position;

        public MapPage()
        {
            GetMyLocation();

            //creates map
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.1)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //creates pin on map
            var pin = new Pin()
            {
                Position = new Position(position.Latitude + 0.001, position.Longitude + 0.001),
                Label = "Click this text to see charts!",

            };
            map.Pins.Add(pin);
            pin.Clicked += GoToChart;
            //places map onto content page

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }

        async void GetMyLocation()
        {
            var locator = CrossGeolocator.Current;
            position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));
        }

        //navigates to new page with graphs on them
        async void GoToChart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs());

        }
    }
}