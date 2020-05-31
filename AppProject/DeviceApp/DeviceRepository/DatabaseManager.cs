using DeviceDB;

namespace Repository
{
    class DatabaseManager
    {
        private static readonly SmartHomeDevicesContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new SmartHomeDevicesContext();
        }

        // Provide an accessor to the database
        public static SmartHomeDevicesContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
