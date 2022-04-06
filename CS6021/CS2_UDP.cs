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
    class CS2_UDP
    {
        IPAddress ipAddress;

        UdpClient udpClnt;
        IPEndPoint RemoteIPEndPointTx;
        IPEndPoint LocalIPEndPointRx;

        public bool b_IsConnected = false;
        public bool b_TrackPowerActive = false;

        private static byte[] sendBytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        private static readonly byte[] CMD_SYSTEM_STOP = { 0x00, 0x00, 0x47, 0x11, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private static readonly byte[] CMD_SYSTEM_GO = { 0x00, 0x00, 0x47, 0x11, 0x05, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        private static readonly byte[] CMD_SYSTEM_HALT = { 0x00, 0x00, 47, 11, 5, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 };
        private static readonly byte[] CMD_CYCLE_END = { 0x00, 0x00, 0x47, 0x11, 0x05, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00 };
        private static readonly byte[] CMD_MFX_DISCOVERY = { 0x00, 0x02, 47, 11, 1, 0x20, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 };

        /// <summary>
        /// Setup network connection to CS3 via UDP (TCP would optionally be available on CS3)
        /// UDP --> CS3-Settings: CAN-Gateway must be set to "broadcast" and IP-adress must be given
        /// TCP --> CS3-Settings: CAN-Gateway must be set to "auto"
        /// Parameters:
        ///     none
        /// Returns:
        ///     0  = success
        ///     -1 = Failed to establish connection
        ///     -2 = exeption occured
        /// </summary>
        public int SetupConnection(string s_IpAddress_Hostname)
        {
            udpClnt = new UdpClient();
            Ping pingSender = new Ping();

            try
            {
                // get IP address
                if (int.TryParse(s_IpAddress_Hostname.Substring(0, 1), out int result))
                {
                    // the given parameter must be IP address
                    ipAddress = IPAddress.Parse(s_IpAddress_Hostname);
                }
                else
                {
                    // the given parameter must be Hostname
                    ipAddress = Dns.GetHostAddresses(s_IpAddress_Hostname)[0];
                }

                // ping the command station, to see if its connected and reachable
                //PingReply reply = pingSender.Send(ipAddress, 10);
                if(true)
                //if (reply.Status == IPStatus.Success)
                {
                    RemoteIPEndPointTx = new IPEndPoint(ipAddress, 15731);
                    LocalIPEndPointRx = new IPEndPoint(IPAddress.Any, 15730);

                    udpClnt.ExclusiveAddressUse = false;
                    udpClnt.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    udpClnt.Client.Bind(LocalIPEndPointRx);

                    b_IsConnected = true;
                    return 0;
                }
                else
                {
                    return -1; // connection could not be established
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -2;
            }
        }



        /// <summary>
        /// End network connection to CS3.
        /// Parameters:
        ///     none
        /// Returns:
        ///     0  = success
        ///     -2 = exeption occured
        /// </summary>
        public int EndConnection()
        {
            try
            {
                udpClnt.Close();
                b_IsConnected = false;
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -2;
            }
        }



        /// <summary>
        /// Send command to CS3 to activate voltage on tracks
        /// 
        /// Parameters:
        ///     none
        /// Returns:
        ///     none
        /// </summary>
        public void ActivateTracks()
        {
            try
            {
                udpClnt.Send(CMD_SYSTEM_GO, 13, RemoteIPEndPointTx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        /// <summary>
        /// Send command to CS3 to deactivate voltage on tracks
        /// 
        /// Parameters:
        ///     none
        /// Returns:
        ///     none
        /// </summary>
        public void DeactivateTracks()
        {
            try
            {
                udpClnt.Send(CMD_SYSTEM_STOP, 13, RemoteIPEndPointTx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        /// <summary>
        /// Send command to CS3 to set locomotives speed
        /// 
        /// Parameters:
        ///     Instance of Locomotive class
        /// Returns:
        ///     none
        /// </summary>
        public void SetLocomotiveSpeed(Locomotive Loc)
        {
            int speed = Loc.Speed * 8; // because Locomotive class is 0..125 and CS3 expects 0..1000

            sendBytes[0] = 0x00;
            sendBytes[1] = 0x08; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 6; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.Protocol;
            sendBytes[8] = Loc.Address;
            sendBytes[9] = (byte)(speed >> 8);
            sendBytes[10] = (byte)speed;

            try
            {
                udpClnt.Send(sendBytes, 13, RemoteIPEndPointTx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        /// <summary>
        /// Send command to CS3 to set locomotives direction
        /// 
        /// Parameters:
        ///     Instance of Locomotive class
        /// Returns:
        ///     none
        /// </summary>
        public void SetLocomotiveDirection(Locomotive Loc)
        {
            // change direction numbers according to Locomotive Class
            int direction = 1;
            if (Loc.Direction == 0) { direction = 2; }// Backwards according to Locomotive Class, Forwards keeps 1
            //if (direction == 0) { direction = 2; }// Backwards according to Locomotive Class, Forwards keeps 1

            sendBytes[0] = 0x00;
            sendBytes[1] = 0x0A; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 5; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.Protocol;
            sendBytes[8] = Loc.Address;
            sendBytes[9] = (byte)direction;

            try
            {
                udpClnt.Send(sendBytes, 13, RemoteIPEndPointTx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        /// <summary>
        /// Send command to CS3 to activate/deactivate a function of the locomotive
        /// 
        /// Parameters:
        ///     Instance of Locomotive class
        ///     functionNumber: 0 = F0   ...   31 = F31
        ///     functionValue: 0 = Off, 1 – 31 = On
        /// Returns:
        ///     none
        /// </summary>
        public void SetLocomotiveFunction(Locomotive Loc, int function)
        {
            sendBytes[0] = 0x00;
            sendBytes[1] = 0x0C; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 6; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.Protocol;
            sendBytes[8] = Loc.Address;
            sendBytes[9] = (byte)function;
            sendBytes[10] = Convert.ToByte(Loc.FunctionsState[function]);

            try
            {
                udpClnt.Send(sendBytes, 13, RemoteIPEndPointTx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
