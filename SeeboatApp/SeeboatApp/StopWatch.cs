using Android.OS;
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
        
        

        public StopWatch(Xamarin.Forms.Label label)
        {
            Timer1.Interval = 1000;
            Timer1.Start();
            Timer1.Elapsed += timer1_Tick;
            timerLabel = label;
            
               

        }


        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

        }
        
        private void timer1_Tick(Object source, System.Timers.ElapsedEventArgs e)
        {
           if(TimeLeft>0)
            {
                
                TimeLeft--;
                System.Diagnostics.Debug.WriteLine(TimeLeft);
                
            }
           else
            {
                Timer1.Stop();
            }
        }
            
    }
}
