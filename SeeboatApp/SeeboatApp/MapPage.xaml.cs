﻿using System;
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
                Text = "Update Pins"
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
            //map.Pins.Clear();



        }

        public void UpdatePins(object sender, EventArgs e)
        {

            List<int> boatIDs = dataPuller.getIDs();

            map.Pins.Clear();
            System.Diagnostics.Debug.WriteLine("Started pin update");
            foreach (int key in boatIDs)
            {
                map.Pins.Add(new Pin { Type = PinType.Place, Label = "Boat #" + key, Position = dataPuller.boats[key].GPS });
            }
            

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
            await Navigation.PushAsync(new Graphs(((Pin)sender).Label, dataPuller));
        }

        private async void AboutItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

    }
}