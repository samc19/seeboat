using Microcharts;
using System;
using System.Collections.Generic;
using System.Timers;


namespace SeeboatApp
{
    public class Retriever
    {

        Timer Timer1 = new Timer();
        public Dictionary<int, BoatData> boats { get; }
        public List<int> IDs;
        //CloudPull puller;
        //int numBoats;



        public Retriever()
        {

            boats = new Dictionary<int, BoatData>();
            IDs = new List<int>();
            boats.Add(1, new BoatData(1));
            IDs.Add(1);
            boats.Add(2, new BoatData(2));
            IDs.Add(2);
            Timer1.Interval = 5000;
            Timer1.Elapsed += Update;
            Timer1.Start();
            //puller = new CloudPull();
            //numBoats = 1;
            //while (puller.PullFromCloud(numBoats.ToString()))
            //{
              //  numBoats++;
            //}
            //for(int i=0; i< 100; i++)
            //{
             //   System.Diagnostics.Debug.Write("*****");
            //}
            //System.Diagnostics.Debug.WriteLine(numBoats);



        }

        public void Update(object sender, ElapsedEventArgs e)
        {
            Random rand = new Random();
            DateTime time = new DateTime();
            String randomData = "26,42.359252,-71.081048,5,34,59,2," + rand.Next(400) + "," + rand.Next(400) + "," + rand.Next(400) + "," + rand.Next(400);
            String randomData2 = "26,42.357349,-71.077718,5,34,59,2," + rand.Next(400) + "," + rand.Next(400) + "," + rand.Next(400) + "," + rand.Next(400);
            FileParser reader = new FileParser(randomData);
            FileParser reader2 = new FileParser(randomData2);
            double[] data = reader.FileToArray();
            double[] data2 = reader2.FileToArray();
            boats[1].AddData(data);
            boats[2].AddData(data2);
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

        

        public float GetGlobalMax(String dataType)
        {
            float max = 0;

            foreach (int key in IDs)
            {
                if (boats[key].FindLargest(dataType) > max)
                    max = boats[key].FindLargest(dataType);
            }
            return max;
        }

        public float GetGlobalMin(String dataType, float maxValue)
        {
            float min = maxValue;

            foreach (int key in IDs)
            {
                if (boats[key].FindLeast(dataType, maxValue) < min)
                    min = boats[key].FindLeast(dataType, maxValue);
            }
            return min;
        }

        public float GetGlobalAvg(String dataType)
        {
            float avg = 0;
            foreach (int key in IDs)
            {
                avg += boats[key].GetAverage(dataType);
            }
            return avg / IDs.Count;
        }
    }
}