
using FileReader;
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
        Retriever dataPuller;
        public MainPage()
        {
            InitializeComponent();
            dataPuller = new Retriever();
        }

        async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Graphs(1, dataPuller));

        }


    }
}
