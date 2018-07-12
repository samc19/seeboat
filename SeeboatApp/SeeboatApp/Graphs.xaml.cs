using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;
using SeeboatApp;

namespace SeeboatApp

{
    public partial class Graphs : ContentPage
    {
        BoatData source = new BoatData();
       





        public Graphs()
        {
            InitializeComponent();
            Chart1.Chart = new LineChart
            {
                Entries = source.GetTemps(),
                LineMode = LineMode.Straight

            };
            Chart2.Chart = new LineChart
            {
                Entries = source.GetConds(),
                LineMode = LineMode.Straight
            };
            Chart3.Chart = new LineChart
            {
                Entries = source.GetPHs(),
                LineMode = LineMode.Straight

            };
            Chart4.Chart = new LineChart
            {
                Entries = source.GetTurbs(),
                LineMode = LineMode.Straight
            };
        }
    }
}
