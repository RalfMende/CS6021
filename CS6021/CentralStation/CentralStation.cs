using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace CS6021
{
    public static class CentralStation
    {
        private static string centralStationType = "CS2_UDP";//null;
        public static bool IsConnected = false;
        public static bool TrackPowerActive = false;

        public static int SetupConnection(string ipAddress_Hostname)
        {
            int retVal = 0;
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        if (CS2_UDP.SetupConnection(ipAddress_Hostname) > 0)
                        {
                            IsConnected = CS2_UDP.IsConnected;
                        }
                        retVal = 1;
                        break;

                    default:
                        retVal = -2;
                        break;
                }
            }
            else
            {
                //TODO: try to get which CentralStation is used by response?
                retVal = -1;
            }
            return retVal;
        }

        public static int EndConnection()
        {
            int retVal = 0;
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        if (CS2_UDP.EndConnection() > 0)
                        {
                            IsConnected = CS2_UDP.IsConnected;
                        }
                        retVal = 1;
                        break;

                    default:
                        retVal = -2;
                        break;
                }
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }

        public static void ActivateTracks()
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.ActivateTracks();
                        break;

                    default:
                        break;
                }
            }
        }

        public static void DeactivateTracks()
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.DeactivateTracks();
                        break;

                    default:
                        break;
                }
            }
        }

        public static void SetLocomotiveSpeed(Locomotive Loc)
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.SetLocomotiveSpeed(Loc);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void SetLocomotiveDirection(Locomotive Loc)
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.SetLocomotiveDirection(Loc);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void SetLocomotiveFunction(Locomotive Loc, int function)
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.SetLocomotiveFunction(Loc, function);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void SetAccessoryState(Accessory accessory, Accessory.e_Position position)
        {
            if (centralStationType != null)
            {
                switch (centralStationType)
                {
                    case "CS2_UDP":
                        CS2_UDP.SetAccessoryState(accessory, position);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
