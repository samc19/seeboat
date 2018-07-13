using System;
using System.Collections.Generic;
using System.Text;

namespace SeeboatApp
{
    class BoatDataStruct
    {
        int deviceID; //store this nodeId
        float GPSlat; //latitude
        float GPSlong;   //              //send all the time parts individually; strings have been annoying to send
        int GPShour;
        int GPSmin;
        int GPSsec;
        int GPSms;
        float tempVal; //temperature value
        float condVal;
        float pHVal;
        float milliIrradiance;
    }
}

