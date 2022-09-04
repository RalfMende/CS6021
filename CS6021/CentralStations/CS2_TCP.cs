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
    class CS2_TCP
    {
        IPAddress ipAddress;

        TcpClient tcpClnt;
        TcpClient TcpClntRx;
        NetworkStream StreamTx; //-->TODO : wieder löschen
        NetworkStream StreamRx; //-->TODO : wieder löschen
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
        ///     1  = success
        ///     -1 = Failed to establish connection
        ///     -2 = exeption occured
        /// </summary>
        public int SetupConnection(string s_IpAddress_Hostname)
        {
            tcpClnt = new TcpClient();
            TcpClntRx = new TcpClient();
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
                PingReply reply = pingSender.Send(ipAddress, 10);
                if (reply.Status == IPStatus.Success)
                {
                    RemoteIPEndPointTx = new IPEndPoint(ipAddress, 15731);
                    LocalIPEndPointRx = new IPEndPoint(IPAddress.Any, 15730);

                    //tcpClnt.ExclusiveAddressUse = false;
                    //tcpClnt.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    tcpClnt.Client.Bind(LocalIPEndPointRx);
                    tcpClnt.Connect(RemoteIPEndPointTx);
                    //TcpClntRx.Client.Bind(LocalIPEndPointRx);

                    StreamTx = tcpClnt.GetStream();// Get a client stream for reading and writing. --> Only TCP
                    //StreamRx = TcpClntRx.GetStream();

                    b_IsConnected = true;
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
        public int EndConnection()
        {
            try
            {
                StreamTx.Close();
                tcpClnt.Close();
                b_IsConnected = false;
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
        public void ActivateTracks()
        {
            try
            {
                StreamTx.Write(CMD_SYSTEM_GO, 0, 13);
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
                StreamTx.Write(CMD_SYSTEM_STOP, 0, 13);

                byte[] receivedData = new byte[13];
                StreamTx.Read(receivedData, 0, 13);
                Debug.Print(receivedData.ToString());
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
                StreamTx.Write(sendBytes, 0, 13);
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
                StreamTx.Write(sendBytes, 0, 13);
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
            sendBytes[7] = (byte)Loc.protocol;
            sendBytes[8] = Loc.address;
            sendBytes[9] = (byte)function;
            sendBytes[10] = Convert.ToByte(Loc.functionsState[function]);

            try
            {
                StreamTx.Write(sendBytes, 0, 13);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void GetConfigData()
        {
            string filename = "loks";
            byte[] byteArrayFilename = Encoding.ASCII.GetBytes(filename);
            int Prio = 0;
            int Command = 0;
            int Response = 0;
            int Hash = 0;
            int DLC = 0;



            sendBytes[0] = 0x00;
            sendBytes[1] = 0x40; // CAN-ID
            sendBytes[2] = 47;
            sendBytes[3] = 11;
            sendBytes[4] = 8; // DLC
            sendBytes[5] = byteArrayFilename[0];
            sendBytes[6] = byteArrayFilename[1];
            sendBytes[7] = byteArrayFilename[2];
            sendBytes[8] = byteArrayFilename[3];
            sendBytes[9] = 0x00;
            sendBytes[10] = 0x00;
            sendBytes[11] = 0x00;
            sendBytes[12] = 0x00;

            try
            {
                //udpClient.Send(sendBytes, 13, RemoteIPEndPointTx);
                //Stream.Write(sendBytes, 0, 13);

                //Client.Send(CMD_SYSTEM_GO, 13);
                //Stream.Write(CMD_SYSTEM_GO, 0, 13);

                //byte[] receivedData = new byte[13];
                //Stream.Read(receivedData,0,13);
                //DLC = Convert.ToInt32(receivedData[4] & 0x0F);
                //Hash = Convert.ToInt32(receivedData[4] & 0xF0);

                //receivedData = Client.Receive(ref RemoteIPEndPoint_CS3);

                Console.WriteLine(filename);






            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void StartLocomotiveDiscovery()
        {
            try
            {
                StreamTx.Write(CMD_MFX_DISCOVERY, 0, 13);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

}
