using System;
namespace CS6021
{
    public class Memory
    {
        public Memory()
        {
        }

        ~Memory()
        {
        }

        public string nameOfInstance = "newMemory";
        public Route[] routeArray = new Route[24];

        /*--------------------------------------------------------------------*/

        public int SetRoute(int id)
        {
            int retVal = 0;
            if (CentralStation.IsConnected == true)
            {
                foreach (Accessory accessory in this.routeArray[id - 1].accessories)
                {
                    CentralStation.SetAccessoryState(accessory, accessory.Position);
                }
                retVal = 1;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }
    }
}
