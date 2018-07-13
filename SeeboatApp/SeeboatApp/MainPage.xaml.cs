using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeeboatApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            FileParser file = new FileParser("FileParser.cs");
            double[] data = file.FileToArray();
		}

        async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs());

        }

        public void StartTimerClicked(object sender, EventArgs e)
        {
            StopWatch counter = new StopWatch(countdown);
        }
    }
}
