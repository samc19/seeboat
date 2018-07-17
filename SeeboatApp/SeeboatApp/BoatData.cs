using System;
using System.Collections.Generic;
using System.Text;
using FileReader;
using Microcharts;
using Xamarin.Forms.Maps;

namespace SeeboatApp
{
    public class BoatData
    {
        
        public List<Entry> temps { get; }
        public List<Entry> pHs { get; }
        public List<Entry> conds { get; }
        public List<Entry> turbs { get; }
        public Position GPS { get; set; }


        public BoatData()
        {
            
            temps = new List<Entry> {
                new Entry(200)
                {
                    Label = "Hi",
                    ValueLabel = "200"
                },

                new Entry(400)
                {
                    Label = "Hi",
                    ValueLabel = "400"
                }
            };
            pHs = new List<Entry> { new Entry(200)
                {
                    Label = "Hi",
                    ValueLabel = "200"
                }

            ,

                new Entry(400)
                {
                    Label = "Hi",
                    ValueLabel = "400"
                }};
            conds = new List<Entry> {new Entry(200)
                {
                    Label = "Hi",
                    ValueLabel = "200"
                }
            ,

                new Entry(400)
                {
                    Label = "Hi",
                    ValueLabel = "400"
                }};
            turbs = new List<Entry> { new Entry(200)
                {
                    Label = "Hi",
                    ValueLabel = "200"
                }
            ,

                new Entry(400)
                {
                    Label = "Hi",
                    ValueLabel = "400"
                }};

            GPS = new Position(42.361598, -71.081279);

        }

        public bool AddData(double[] data)
        {
            if (data[7] != 0)
            {
                String time = ConvertTime(data);
                Entry[] entries = new Entry[4];
                int j = 0;
                for (int i = 6; i < 10; i++)
                {
                    entries[j] = MakeEntry(data[i], time);
                    j++;
                }
                UpdateLists(entries);
                GPS = new Position(data[1], data[2]);
                return true;
            }
            return false;
        }

        private String ConvertTime(double[] data)
        {
            string time = data[3] + data[4] + data[5] + "";
            return time;
        }

        private Entry MakeEntry(double point, String time)
        {
            Entry dataPoint = new Entry((float)point)
            {
                Label = time,
                ValueLabel = point + ""

            };
            return dataPoint;
        }

        private void UpdateLists(Entry[] data)
        {
            temps.Add(data[0]);
            conds.Add(data[1]);
            pHs.Add(data[2]);
            turbs.Add(data[3]);
        }

       
    }
}
