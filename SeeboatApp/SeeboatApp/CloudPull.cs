using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace SeeboatApp
{
    class CloudPull
    {
        //Do not change these 3 lines unless it is just changing the names of the objects. These lines are the connection to the cloud
        readonly static CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=tealseeboateeststorage;AccountKey=F5GnHieen8Az50v0oR9cIkf7AywiF1O9vQI53TyNy4GqnpbFmzOrM1ztQ+NWf8ph/GfnQyrXe9usjY/tJBHIRA==;EndpointSuffix=core.windows.net");
        readonly static CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();
        CloudTable dummyDataTable;

        public CloudPull()
        {
            dummyDataTable = tableClient.GetTableReference("TestSeeboatData");
        }
        //This method isn't tested feel free to change if needed
        public bool PullFromCloud(String partitionKey)
        {
            
            try
            {
                Pull(partitionKey);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Use this to test if the connection to the cloud works 
        public bool DoesTableExist()
        {
            return dummyDataTable.ExistsAsync().Result;
        }

        public void Pull(String partition)
        {
            // TableQuery<BoatDataStructure> query = new TableQuery<BoatDataStructure>().Where(TableQuery.GenerateFilterCondition("PartitionKey", 
            //teTimeOffset.Now.AddDays(3).Da
            //var resultSegment = dummyDataTable.ExecuteQuerySegmentedAsync(query, null);
           //ableBatchOperation TableOperator = new TableBatchOperation();  //(dummyDataTable.ExecuteAsync(TableOperation.Retrieve("boat1", "1")));
           // TableOperator.Add(TableOperation.Retrieve("boat1");
            //dummyDataTable.ExecuteBatchAsync(TableOperator);
            //BoatDataStructure boatEntry = TableOperator.
                //resultSegment.Start();
            //if(resultSegment.Result == null)                       //SAM SAM SAM!! If you get here first don't delete the commented out code. I'm Trying to see if I can execute a retrive operation then access the result
            //{
              //  throw new Exception();
            //}
        }
    }
}