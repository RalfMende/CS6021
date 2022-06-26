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
    public static class CS2_UDP
    {
        static IPAddress ipAddress;
        static UdpClient udpClnt;
        static IPEndPoint remoteEP_TX;
        static IPEndPoint localEP_RX;
        public static bool IsConnected = false;
        public static bool TrackPowerActive = false;
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
        ///     1  = success
        ///     -1 = Failed to establish connection
        ///     -2 = exeption occured
        /// </summary>
        public static int SetupConnection(string s_IpAddress_Hostname)
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
                    remoteEP_TX = new IPEndPoint(ipAddress, 15731);
                    //localEP_RX = new IPEndPoint(IPAddress.Any, 15730);
                    localEP_RX = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 15730);

                    //udpClnt.Connect(remoteEP_TX);

                    //udpClnt.ExclusiveAddressUse = false;
                    //udpClnt.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    udpClnt.Client.Bind(localEP_RX);

                    IsConnected = true;
                    return 1;
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
        ///     1  = success
        ///     -2 = exeption occured
        /// </summary>
        public static int EndConnection()
        {
            try
            {
                udpClnt.Close();
                IsConnected = false;
                return 1;
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
        public static void ActivateTracks()
        {
            try
            {
                udpClnt.Send(CMD_SYSTEM_GO, 13, remoteEP_TX);

                //Byte[] receiveBytes = udpClnt.Receive(ref localEP_RX);
                //Debug.Print("");
                //udpClnt.BeginReceive(new AsyncCallback(recv), null);

                TrackPowerActive = true; //TODO: get this set by CS2 response
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //CallBack
        /*private void recv(IAsyncResult res)
        {
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 15730);
            byte[] received = udpClnt.EndReceive(res, ref localEP_RX);
            Debug.Print("");
        }*/



        /// <summary>
        /// Send command to CS3 to deactivate voltage on tracks
        /// 
        /// Parameters:
        ///     none
        /// Returns:
        ///     none
        /// </summary>
        public static void DeactivateTracks()
        {
            try
            {
                udpClnt.Send(CMD_SYSTEM_STOP, 13, remoteEP_TX);
                TrackPowerActive = false; //TODO: get this set by CS2 response
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
        public static void SetLocomotiveSpeed(Locomotive Loc)
        {
            int speed = Loc.speed * 8; // because Locomotive class is 0..125 and CS3 expects 0..1000

            sendBytes[0] = 0x00;
            sendBytes[1] = 0x08; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 6; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.protocol;
            sendBytes[8] = Loc.address;
            sendBytes[9] = (byte)(speed >> 8);
            sendBytes[10] = (byte)speed;

            try
            {
                udpClnt.Send(sendBytes, 13, remoteEP_TX);
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
        public static void SetLocomotiveDirection(Locomotive Loc)
        {
            // change direction numbers according to Locomotive Class
            int direction = 1;
            if (Loc.direction == 0) { direction = 2; }// Backwards according to Locomotive Class, Forwards keeps 1
            //if (direction == 0) { direction = 2; }// Backwards according to Locomotive Class, Forwards keeps 1

            sendBytes[0] = 0x00;
            sendBytes[1] = 0x0A; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 5; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.protocol;
            sendBytes[8] = Loc.address;
            sendBytes[9] = (byte)direction;

            try
            {
                udpClnt.Send(sendBytes, 13, remoteEP_TX);
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
        public static void SetLocomotiveFunction(Locomotive Loc, int function)
        {
            sendBytes[0] = 0x00;
            sendBytes[1] = 0x0C; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 6; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)Loc.protocol;
            sendBytes[8] = Loc.address;
            sendBytes[9] = (byte)function;
            sendBytes[10] = Convert.ToByte(Loc.functionsState[function]);

            try
            {
                udpClnt.Send(sendBytes, 13, remoteEP_TX);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        /// <summary>
        /// Send command to CS3 to set position of accessory
        /// 
        /// Parameters:
        ///     Instance of Accessory class
        ///     Pos: 0 / 1
        /// Returns:
        ///     none
        /// </summary>
        public static void SetAccessoryState(Accessory accessory, Accessory.e_Position position)
        {
            sendBytes[0] = 0x00;
            sendBytes[1] = 0x0C; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 6; // DLC
            sendBytes[5] = 0x00;
            sendBytes[6] = 0x00;
            sendBytes[7] = (byte)accessory.Protocol;
            sendBytes[8] = accessory.id;
            sendBytes[9] = (byte)position;
            sendBytes[10] = 0x00;

            try
            {
                udpClnt.Send(sendBytes, 13, remoteEP_TX);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
