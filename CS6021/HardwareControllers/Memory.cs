using System;
namespace CS6021
{
    public class Memory
    {
        public string nameOfInstance;

        private Route[] routeArray;

        public Memory()
        {
            this.nameOfInstance = "newMemory";
            this.routeArray = new Route[24];
        }

        public Memory(string name)
        {
            this.nameOfInstance = name;
            this.routeArray = new Route[24];
        }

        ~Memory()
        {
        }

        /*--------------------------------------------------------------------*/

        public int SetRoute(int id)
        {
            int retVal = 0;
            if (CentralStation.isConnected == true)
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
