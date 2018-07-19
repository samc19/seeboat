using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Timers;


namespace SeeboatApp
{
    public partial class MapPage : ContentPage
    {
        Map map;
        Retriever dataPuller;
        Timer timer;
        public MapPage()
        {
            timer = new Timer();
            dataPuller = new Retriever();
            timer.Interval = 10000;
            timer.Elapsed += UpdatePins;
            timer.Start();
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
                Position = dataPuller.boats[1].GPS,
                Label = "BOAT ID"
            };
            map.Pins.Add(pin);
            pin.Clicked += GoToChart;


            //places map onto content page

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;

            //adds toolbaritems
            var AboutItem = new ToolbarItem
            {
                Text = "About",
                Order = ToolbarItemOrder.Secondary
            };

            this.ToolbarItems.Add(AboutItem);
            //map.Pins.Clear();



        }

        public void UpdatePins(object sender, EventArgs e)
        {

            List<int> boatIDs = dataPuller.getIDs();

            map.Pins.Clear();
            System.Diagnostics.Debug.WriteLine("Started pin update");
            for (int i = 0; i < boatIDs.Count; i++)
            {
                map.Pins.Add(new Pin { Type = PinType.Place, Label = "Boat #" + boatIDs[i], Position = dataPuller.boats[i].GPS });
                System.Diagnostics.Debug.WriteLine("Done with" + i);
            }
            System.Diagnostics.Debug.WriteLine("Finished pin update");

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