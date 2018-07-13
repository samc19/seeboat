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

        //button is clicked to create map
        private void GetMap_Clicked(object sender, EventArgs e)
        {
            GenerateMapAroundLocation();
        }

        //creates new MapPage
        async void GenerateMapAroundLocation()
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
	}

