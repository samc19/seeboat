using System;
using System.Collections.Generic;
using System.Timers;


namespace SeeboatApp
{
    public class Retriever
    {

        Timer Timer1 = new Timer();
        public Dictionary<int, BoatData> boats { get; }



        public Retriever()
        {

            boats = new Dictionary<int, BoatData>();
            boats.Add(1, new BoatData(1));
            Timer1.Interval = 5000;
            Timer1.Elapsed += Update;
            Timer1.Start();



        }

        public void Update(object sender, ElapsedEventArgs e)
        {
            FileParser reader = new FileParser("26,23.09,45.80,5,34,59,2,67.9,34.7,4.9,45.34");
            
            boats[1].AddData(reader.FileToArray());
            System.Diagnostics.Debug.WriteLine("Update started");

            //Will call BoatData.AddData
        }

        public void UpdateTest()
        {
            FileParser reader = new FileParser("26,23.09,45.80,5,34,59,2,67.9,34.7,4.9,45.34");
            boats[1].AddData(reader.FileToArray());
            //Will call BoatData.AddData
        }

        public BoatData GetData(int boatID)
        {
            return boats[boatID];
        }

        public List<int> getIDs()
        {
            /*List<int> IDs = new List<int>();
            for(int i=0; i<boats.Count; i++)
            {
                IDs.Add(boats[i].ID);
            }
            return IDs;*/
            return new List<int> { 1 };
        }
    }
}