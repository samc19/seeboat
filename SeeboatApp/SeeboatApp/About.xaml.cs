using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeboatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }

        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });

        private void GitHub_Clicked(object sender, EventArgs e)
        { 
            Device.OpenUri(new System.Uri("https://github.com/lperovich/seeboat/"));
        }

        private void LauraWebsite_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new System.Uri("http://www.lauraperovich.com/projects/seeBoat.html"));
        }
    }
}