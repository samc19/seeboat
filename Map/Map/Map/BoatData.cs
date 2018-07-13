using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;

namespace MapApp
{
    class BoatData
    {
        private List<Entry> temps;
        private List<Entry> pHs;
        private List<Entry> conds;
        private List<Entry> turbs;


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

        }

        public bool AddData(int[] data)
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
                return true;
            }
            return false;
        }

        private String ConvertTime(int[] data)
        {
            string time = data[3] + data[4] + data[5] + "";
            return time;
        }

        private Entry MakeEntry(int point, String time)
        {
            Entry dataPoint = new Entry(point)
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

        public List<Entry> GetTemps()
        {
            return temps;
        }

        public List<Entry> GetConds()
        {
            return conds;
        }

        public List<Entry> GetTurbs()
        {
            return turbs;
        }

        public List<Entry> GetPHs()
        {
            return pHs;
        }

    }
}