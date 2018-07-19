using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts.Forms;
using Microcharts;

namespace SeeboatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphFocus : ContentPage
    {
        public int ID;
        public Retriever dataSource;
        public BoatData source;
        public new string Title;
        public GraphFocus(Retriever input, int BoatID, String GraphTitle)
        {
            InitializeComponent();
            dataSource = input;
            Title = GraphTitle;
            TitleDisplay.Text = GraphTitle;
            ID = BoatID;
            Update();
            //Average.Text = "Average Value: " + GetAverage().ToString();
            //Max.Text = maxValue;




        }

        public void Update()
        {
            UpdateSource();
            UpdateGraph();
            Average.Text = "Average Value: " + GetAverage().ToString();
            Max.Text = "Maximum Value: " + ChartFocus.Chart.MaxValue.ToString();
        }

        private void UpdateGraph()
        {
            if (Title.Equals("Temperature"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.tempsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (Title.Equals("Conductivity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.condsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (Title.Equals("Turbidity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.turbsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (Title.Equals("pH Value"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.pHsStore,
                    LineMode = LineMode.Straight

                };
            }



        }
        private void UpdateSource()
        {
            //dataSource.UpdateTest();
            source = dataSource.GetData(ID);

        }

        public void Refresh_Clicked(object sender, ClickedEventArgs e)
        {
            //dataSource.Update();
            Update();
        }

        public float GetAverage()
        {
            float sum;
            if (Title.Equals("Temperature"))
                sum = source.SumTempsStore();
            else if (Title.Equals("Conductivity"))
                sum = source.SumCondsStore();
            else if (Title.Equals("Turbidity"))
                sum = source.SumTurbsStore();
            else if (Title.Equals("pH Value"))
                sum = source.SumPHsStore();
            else
                sum = 0;
            return sum / source.temps.Count;
        }
    }
}