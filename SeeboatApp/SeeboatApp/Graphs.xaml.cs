using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;
using System.Timers;

namespace SeeboatApp

{
    public partial class Graphs : ContentPage
    {
        BoatData source;
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
            //dataSource.UpdateTest();
            source = dataSource.GetData(BoatID);

        }


        public void Update(object sender, ElapsedEventArgs e)
        {
            UpdateSource();
            UpdateGraphs();
        }

        public Graphs(String boatID, Retriever retriever)
        {
            InitializeComponent();
            dataSource = retriever;

            BoatID = int.Parse(boatID.Substring(boatID.IndexOf(" ")+1));
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


        }

        async void Chart1_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            await Navigation.PushAsync(new GraphFocus(dataSource, BoatID, Label1.Text ));
        }

        async void Chart2_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            await Navigation.PushAsync(new GraphFocus(dataSource, BoatID, Label2.Text ));
        }

        async void Chart3_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            await Navigation.PushAsync(new GraphFocus(dataSource, BoatID, Label3.Text ));
        }

        async void Chart4_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            await Navigation.PushAsync(new GraphFocus(dataSource, BoatID, Label4.Text ));
        }                                                                                                              
    }
}