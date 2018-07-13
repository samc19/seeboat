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
                Entries = source.temps,
                LineMode = LineMode.Straight

            };
            Chart2.Chart = new LineChart
            {
                Entries = source.conds,
                LineMode = LineMode.Straight
            };
            Chart3.Chart = new LineChart
            {
                Entries = source.pHs,
                LineMode = LineMode.Straight

            };
            Chart4.Chart = new LineChart
            {
                Entries = source.turbs,
                LineMode = LineMode.Straight
            };
        }
    }
}
