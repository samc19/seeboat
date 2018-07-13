using Android.OS;
using FileReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace SeeboatApp
{
    class StopWatch
    {
        int TimeLeft = 10;
        Timer Timer1 = new Timer();
        Label timerLabel;
        Dictionary<string, BoatData> boats;



        public StopWatch(Xamarin.Forms.Label label)
        {
            Timer1.Interval = 1000;
            Timer1.Start();
            Timer1.Elapsed += timer1_Tick;
            timerLabel = label;
            boats = new Dictionary<string, BoatData>(6);
            boats.Add("1", new BoatData());


        }

        private void timer1_Tick(Object source, System.Timers.ElapsedEventArgs e)
        {


            FileParser reader = new FileParser("26,23.09,45.80,5,34,59,2,67.9,34.7,4.9,45.34");
            boats["1"].AddData(reader.FileToArray());
            //Will call BoatData.AddData()
            







        } 
    }
}
