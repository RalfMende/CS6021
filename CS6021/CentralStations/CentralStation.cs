/*
 * CS6021 - iPad Remote Controller for Märklin Central Station in ControlUnit-Design
 * 
 * Copyright (c) 2022 Ralf Mende
 * 
 * 
 * This file is part of CS6021.
 * 
 * CS6021 is free software: you can redistribute it and/or modify it 
 * under the terms of the GNU General Public License as published by the 
 * Free Software Foundation, either version 3 of the License, or (at your 
 * option) any later version.
 * 
 * CS6021 is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License 
 * along with Foobar. If not, see 
 * <https://www.gnu.org/licenses/>.
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Internal;

namespace CentralStations
{
    public static class CentralStation
    {
        private static string centralStationType = "CS2_UDP";//null;
        public static bool isConnected = false;
        public static bool TrackPowerActive = false;



        /*--------------------------*/

        public static void ConnectToCentralStation(string hostname)
        {

            int returnValue = -1;
            string ipAddressByUser = hostname;// "maerklin-cs3"; //TODO: Change to stored value
            Stopwatch sw = new Stopwatch();

            sw.Start();
            while (true)
            {
                returnValue = CentralStation.SetupConnection(ipAddressByUser);
                if (returnValue < 0)
                {
                    //ipAddressByUser = await DisplayPromptAsync("CentralStation Connection", "Please enter hostname or IP address", initialValue: "maerklin-cs3");
                }
                else
                {
                    isConnected = true;
                    if (ipAddressByUser != null)
                    {
                        //Properties.Settings.Default.ipAddress = ipAddressByUser; //TODO: store value permanently
                    }
                    break;
                }
            }
        }

        /*--------------------------*/







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
                            isConnected = CS2_UDP.IsConnected;
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
                            isConnected = CS2_UDP.IsConnected;
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

        public static void ActivateTrackPower()
        {
            if (centralStationType != null && isConnected == true)
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

        public static void DeactivateTrackPower()
        {
            if (centralStationType != null && isConnected == true)
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
            if (centralStationType != null && isConnected == true)
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
            if (centralStationType != null && isConnected == true)
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
            if (centralStationType != null && isConnected == true)
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
            if (centralStationType != null && isConnected == true)
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
