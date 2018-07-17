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
using System.Timers;

namespace SeeboatApp

{
    public partial class Graphs : ContentPage
    {
        BoatData source = new BoatData();
        int BoatID;
        Retriever dataSource;

        public void Refresh_Clicked(object sender, ClickedEventArgs e)
        {
            //dataSource.Update();
            UpdateSource();
            UpdateGraphs();
        }


        private void UpdateSource()
        {
            //dataSource.Update();
            source = dataSource.GetData("1");
            /*double[] random = new double[11];
            Random rnd = new Random();
            for(int i=0; i<11; i++)
            {
                random[i] = rnd.Next(100);
            }
            source.AddData(random);*/
        }


        public void Update(object sender, ElapsedEventArgs e)
        {
            //dataSource.Update();
            UpdateSource();
            UpdateGraphs();
        }

        public Graphs(int boatID, Retriever retriever)
        {
            InitializeComponent();
            dataSource = retriever;

            BoatID = boatID;
            UpdateSource();
            UpdateGraphs();


            /*for(int i=0; i<10; i++)
            {
                UpdateSource();
                UpdateGraphs();
            }*/
        }
        private void UpdateGraphs()
        {

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
            Chart1.Chart = new LineChart
            {
                Entries = source.temps,
                LineMode = LineMode.Straight

            };
            MaxValue1.Text = "Max Value:" + Chart1.Chart.MaxValue.ToString();

        }
    }
}
