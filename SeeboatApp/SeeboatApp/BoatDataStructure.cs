using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;


namespace SeeboatApp
{
    public class BoatDataStructure : TableEntity
    {

        public BoatDataStructure(string temppartitionkey, string temprowkey)

        {
            this.PartitionKey = temppartitionkey;
            this.RowKey = temprowkey;
        }

        public double DeviceID { get; set; }

        public double GPSlat { get; set; }
        public double GPSlong { get; set; }
        public double GPShour { get; set; }
        public double GPSmin { get; set; }
        public double GPSsec { get; set; }
        public double GPSms { get; set; }
        public double TempVal { get; set; }
        public double CondVal { get; set; }
        public double PhVal { get; set; }
        public double MilliIrradiance { get; set; }
    }

}