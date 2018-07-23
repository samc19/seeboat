using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;
using Plugin.Geolocator.Abstractions;
using Position = Xamarin.Forms.Maps.Position;

namespace SeeboatApp
{
    public class BoatData
    {
        public int ID { get; }
        public List<Entry> temps { get; }
        public List<Entry> pHs { get; }
        public List<Entry> conds { get; }
        public List<Entry> turbs { get; }
        public List<Entry> tempsStore { get; }
        public List<Entry> pHsStore { get; }
        public List<Entry> condsStore { get; }
        public List<Entry> turbsStore { get; }
        public Xamarin.Forms.Maps.Position GPS { get; set; }


        public BoatData(int BoatID)
        { 

            temps = new List<Entry>();
            conds = new List<Entry>();
            turbs = new List<Entry>();
            pHs = new List<Entry>();
            tempsStore = new List<Entry>();
            condsStore = new List<Entry>();
            turbsStore = new List<Entry>();
            pHsStore = new List<Entry>();
            GPS = new Position(42.361598 + ID/100.0, -71.081279);
            ID = BoatID;

        }

        public bool AddData(double[] data)
        {
            if (data[8] != 0)
            {
                String time = ConvertTime(data);
                Entry[] entries = new Entry[4];
                int j = 0;
                for (int i = 7; i < 11; i++)
                {
                    entries[j] = MakeEntry(data[i], time);
                    j++;
                }
                UpdateLists(entries);
                GPS = new Position(data[1], data[2]);
                System.Diagnostics.Debug.WriteLine("Update finished");
                return true;
            }
            return false;
        }

        private String ConvertTime(double[] data)
        {
            string time = data[3] + ":" + data[4] + ":" +  data[5];
            return time;
        }

        private Entry MakeEntry(double point, String time)
        {
            Entry dataPoint = new Entry((float)point)
            {
                Label = time,
                ValueLabel = point + "",
                Color = ColorChooser.ChooseEntryColor((float)point)


            };
            return dataPoint;
        }

        private void UpdateLists(Entry[] data)
        {
            temps.Add(data[0]);
            conds.Add(data[1]);
            pHs.Add(data[2]);
            turbs.Add(data[3]);
            tempsStore.Add(data[0]);
            condsStore.Add(data[1]);
            pHsStore.Add(data[2]);
            turbsStore.Add(data[3]);
            if (temps.Count > 10)
            {
                temps.RemoveAt(0);
                conds.RemoveAt(0);
                pHs.RemoveAt(0);
                turbs.RemoveAt(0);
            }
            if (tempsStore.Count > 25)
            {
                tempsStore.RemoveAt(0);
                condsStore.RemoveAt(0);
                pHsStore.RemoveAt(0);
                turbsStore.RemoveAt(0);
            }
        }

        private float SumList(List<Entry> addends)
        {
            float sum = 0;
            for (int i = 0; i < addends.Count; i++)
            {
                sum += addends[i].Value;
            }
            return sum;
        }


        public float FindSmallest(IEnumerable<Entry> entries, float maxValue)
        {
            float smallest = maxValue;
            foreach(Entry datum in entries)
            {
                if (datum.Value < smallest)
                    smallest = datum.Value;
            }
            return smallest;
        }

        public float FindLeast(String dataType, float maxValue)
        {
            float min = maxValue;
            if (dataType.Equals("Temperature"))
            {

                foreach (Entry entry in tempsStore)
                {
                    if (entry.Value < min)
                        min = entry.Value;
                }
            }
            else if (dataType.Equals("Conductivity"))
            {

                foreach (Entry entry in condsStore)
                {
                    if (entry.Value < min)
                        min = entry.Value;
                }
            }
            else if (dataType.Equals("Turbidity"))
            {

                foreach (Entry entry in turbsStore)
                {
                    if (entry.Value < min)
                        min = entry.Value;
                }
            }
            else if (dataType.Equals("pH"))
            {

                foreach (Entry entry in pHsStore)
                {
                    if (entry.Value < min)
                        min = entry.Value;
                }
            }
            return min;
        }

        public float FindLargest(String dataType)
        {
            float max = 0;
            if(dataType.Equals("Temperature"))
            {
                
                foreach (Entry entry in temps)
                {
                    if (entry.Value > max)
                        max = entry.Value;
                }
            }
            else if (dataType.Equals("Conductivity"))
            {
               
                foreach (Entry entry in condsStore)
                {
                    if (entry.Value > max)
                        max = entry.Value;
                }
            }
            else if (dataType.Equals("Turbidity"))
            {
                
                foreach (Entry entry in turbsStore)
                {
                    if (entry.Value > max)
                        max = entry.Value;
                }
            }
            else if (dataType.Equals("pH"))
            {
                
                foreach (Entry entry in pHsStore)
                {
                    if (entry.Value > max)
                        max = entry.Value;
                }
            }
            return max;
        }
        public float GetAverage(String PageTitle)
        {
            float sum;
            if (PageTitle.Equals("Temperature"))
                sum = SumTempsStore();
            else if (PageTitle.Equals("Conductivity"))
                sum = SumCondsStore();
            else if (PageTitle.Equals("Turbidity"))
                sum = SumTurbsStore();
            else if (PageTitle.Equals("pH"))
                sum = SumPHsStore();
            else
                sum = 0;
            return sum /temps.Count;
        }



        public float SumTempsStore()
        {
            return SumList(tempsStore);
        }

        public float SumCondsStore()
        {
            return SumList(condsStore);
        }

        public float SumPHsStore()
        {
            return SumList(pHsStore);
        }

        public float SumTurbsStore()
        {
            return SumList(turbsStore);
        }

    }
}