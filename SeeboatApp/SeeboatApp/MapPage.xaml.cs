using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Timers;
using System.Threading.Tasks;
using Android.OS;
using Android;
using Android.Content.PM;

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
            Title = "SeeBoat";
            
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

            //creates pin on map
            foreach (int key in dataPuller.boats.Keys)
            {
                var pin = new Pin()
                {
                    Type = PinType.Place,
                    //Position = dataPuller.boats[key].GPS,
                    Position = new Position(42.361598 + (double)key/1000, -71.081279),
                    Label = "Boat " + key.ToString()
                };
                map.Pins.Add(pin);
                pin.Clicked += GoToChart;

            }

            var button = new Button()
            {
                Text = "Update Pins",
                BackgroundColor = Color.FromHex("#8CC739")
            };
            button.Clicked += UpdatePins;

            
            //places map onto content page

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(button);
            Content = stack;

            //adds toolbaritems
            var AboutItem = new ToolbarItem
            {
                Text = "About",
                Order = ToolbarItemOrder.Secondary
            };

            this.ToolbarItems.Add(AboutItem);
            AboutItem.Clicked += AboutItem_Activated;



        }

        public void UpdatePins(object sender, EventArgs e)
        {

            List<int> boatIDs = dataPuller.getIDs();

            map.Pins.Clear();
            System.Diagnostics.Debug.WriteLine("Started pin update");
            foreach (int key in boatIDs)
            {
                var pin = new Pin { Type = PinType.Place, Label = "Boat " + key, Position = dataPuller.boats[key].GPS };
               
                map.Pins.Add(pin);
                pin.Clicked += GoToChart;
            }
            

        }

        async void MoveToMyLocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(3));
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.1)));
        }

        //navigates to new page with graphs on them
        async void GoToChart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs(((Pin)sender).Label, dataPuller));
        }

        private async void AboutItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

    }
}