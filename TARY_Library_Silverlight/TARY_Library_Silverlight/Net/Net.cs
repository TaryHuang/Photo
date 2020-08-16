using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Net.NetworkInformation;
namespace TARY_Library_Silverlight.Net
{
 public class Net
    {

        public static string GetNetStates()
        {
            var info = NetworkInterface.NetworkInterfaceType;
            switch (info)
            {

                case NetworkInterfaceType.MobileBroadbandCdma:
                    return "CDMA";

                case NetworkInterfaceType.MobileBroadbandGsm:
                    return "CSM";

                case NetworkInterfaceType.Wireless80211:
                    return "WiFi";

                case NetworkInterfaceType.Ethernet:
                    return "Ethernet";

                case NetworkInterfaceType.None:
                    return "None";

                default:
                    return "Other";
            }
        }

    }
}
