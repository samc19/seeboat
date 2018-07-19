using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;


namespace MapApp
{
    public partial class MapPage : ContentPage
    {
        Map map;
        Retriever dataPuller;
        public MapPage()
        {
            Title = "SeeBoat";
            dataPuller = new Retriever();

            //adds toolbaritems
            var AboutItem = new ToolbarItem
            {
                Text = "About",
                Order = ToolbarItemOrder.Secondary
            };
            this.ToolbarItems.Add(AboutItem);
            AboutItem.Clicked += AboutItem_Activated;

            //creates map
            map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(0, 0), Distance.FromMiles(0.1)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            MoveToMyLocation();

            //creates pin on map\
            var pin = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(42.36, -71.08),
                Label = "BOAT ID"
            };
            map.Pins.Add(pin);
            pin.Clicked += GoToChart;
            
            //places map onto content page

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
   
        }

        async void MoveToMyLocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(0.001));
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.1)));
        }

        //navigates to new page with graphs on them
        async void GoToChart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs(1, dataPuller));

        }

        private async void AboutItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

    }
}