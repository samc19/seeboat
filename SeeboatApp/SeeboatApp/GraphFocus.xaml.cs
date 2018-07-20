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
        public  string PageTitle;
        public GraphFocus(Retriever input, int BoatID, String GraphTitle)
        {
            InitializeComponent();
            dataSource = input;
            PageTitle = GraphTitle;
            TitleDisplay.Text = GraphTitle;
            Title = "Boat " + BoatID;
            ID = BoatID;
            Update();
            //Average.Text = "Average Value: " + GetAverage().ToString();
            //Max.Text = maxValue;




        }

        public void Update()
        {
            System.Diagnostics.Debug.WriteLine("This is a secret message...");
            UpdateSource();
            UpdateGraph();
            Average.Text = "Average Value: " + GetAverage().ToString();
            Max.Text = "Maximum Value: " + ChartFocus.Chart.MaxValue.ToString();
            Min.Text = "Minimum Value: " + source.FindSmallest(ChartFocus.Chart.Entries, ChartFocus.Chart.MaxValue);
        }

        private void UpdateGraph()
        {
            if (PageTitle.Equals("Temperature"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.tempsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (PageTitle.Equals("Conductivity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.condsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (PageTitle.Equals("Turbidity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.turbsStore,
                    LineMode = LineMode.Straight

                };
            }

            else if (PageTitle.Equals("pH Value"))
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
            if (PageTitle.Equals("Temperature"))
                sum = source.SumTempsStore();
            else if (PageTitle.Equals("Conductivity"))
                sum = source.SumCondsStore();
            else if (PageTitle.Equals("Turbidity"))
                sum = source.SumTurbsStore();
            else if (PageTitle.Equals("pH Value"))
                sum = source.SumPHsStore();
            else
                sum = 0;
            return sum / source.temps.Count;
        }

    }
}