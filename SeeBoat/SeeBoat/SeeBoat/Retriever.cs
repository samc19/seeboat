using System;
using System.Collections.Generic;
using System.Timers;

namespace SeeBoat
{
    public class Retriever
    {

        Timer Timer1 = new Timer();
        Dictionary<string, BoatData> boats;



        public Retriever()
        {

            boats = new Dictionary<string, BoatData>();
            boats.Add("1", new BoatData());
            Timer1.Interval = 5000;
            Timer1.Elapsed += Update;
            Timer1.Start();



        }

        public void Update(object sender, ElapsedEventArgs e)
        {
            FileParser reader = new FileParser("26,23.09,45.80,5,34,59,2,67.9,34.7,4.9,45.34");
            System.Diagnostics.Debug.WriteLine("Update started");
            boats["1"].AddData(reader.FileToArray());
            //Will call BoatData.AddData
        }

        public void UpdateTest()
        {
            FileParser reader = new FileParser("26,23.09,45.80,5,34,59,2,67.9,34.7,4.9,45.34");
            boats["1"].AddData(reader.FileToArray());
            //Will call BoatData.AddData
        }

        public BoatData GetData(String boatID)
        {
            return boats[boatID];
        }
    }
}