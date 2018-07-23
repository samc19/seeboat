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
        public string units = "";
        public GraphFocus(Retriever input, int BoatID, String GraphTitle)
        {
            InitializeComponent();
            dataSource = input;
            PageTitle = GraphTitle;
            TitleDisplay.FontAttributes = FontAttributes.Bold;
            ID = BoatID;
            Update();
            TitleDisplay.Text = GraphTitle + units;
            Title = "Boat " + BoatID;
            BoatName.Text = "Boat " + BoatID;
            
        }

        public void Update()
        {
            System.Diagnostics.Debug.WriteLine("This is a secret message...");
            UpdateSource();
            UpdateGraph();
            Average.Text = source.GetAverage(PageTitle).ToString();
            Max.Text = ChartFocus.Chart.MaxValue.ToString();
            Min.Text = source.FindSmallest(ChartFocus.Chart.Entries, ChartFocus.Chart.MaxValue).ToString();
            GlobalMax.Text = dataSource.GetGlobalMax(PageTitle).ToString();
            GlobalMin.Text = dataSource.GetGlobalMin(PageTitle, float.Parse(Max.Text)).ToString();
            GlobalAvg.Text = dataSource.GetGlobalAvg(PageTitle).ToString();
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
                units = " (degrees Farenheit)";
            }

            else if (PageTitle.Equals("Conductivity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.condsStore,
                    LineMode = LineMode.Straight

                };
                units = " (milliwatts per square meter)";
            }

            else if (PageTitle.Equals("Turbidity"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.turbsStore,
                    LineMode = LineMode.Straight

                };
                units = " (FTU)";
            }

            else if (PageTitle.Equals("pH"))
            {
                ChartFocus.Chart = new LineChart
                {

                    Entries = source.pHsStore,
                    LineMode = LineMode.Straight

                };
                units = "";
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

        private void MoveTurbs_Clicked(object sender, EventArgs e)
        {
            PageTitle = "Turbidity";
            TitleDisplay.Text = PageTitle;
            MoveTurbs.IsEnabled = false;
            MoveConds.IsEnabled = true;
            MovePHs.IsEnabled = true;
            MoveTemps.IsEnabled = true;
            Update();
        }

        private void MoveConds_Clicked(object sender, EventArgs e)
        {
            PageTitle = "Conductivity";
            TitleDisplay.Text = PageTitle;
            MoveTurbs.IsEnabled = true;
            MoveConds.IsEnabled = false;
            MovePHs.IsEnabled = true;
            MoveTemps.IsEnabled = true;
            Update();
        }

        private void MovePHs_Clicked(object sender, EventArgs e)
        {
            PageTitle = "pH";
            TitleDisplay.Text = PageTitle;
            MoveTurbs.IsEnabled = true;
            MoveConds.IsEnabled = true;
            MovePHs.IsEnabled = false;
            MoveTemps.IsEnabled = true;
            Update();
        }

        private void MoveTemps_Clicked(object sender, EventArgs e)
        {
            PageTitle = "Temperature";
            TitleDisplay.Text = PageTitle;
            MoveTurbs.IsEnabled = true;
            MoveConds.IsEnabled = true;
            MovePHs.IsEnabled = true;
            MoveTemps.IsEnabled = false;
            Update();
        }
    }
}