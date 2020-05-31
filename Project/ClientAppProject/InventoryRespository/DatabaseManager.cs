using InventoryDatabase;

namespace InventoryRespository
{
    class DatabaseManager
    {

        private static readonly ClientApplicationsDatabaseContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ClientApplicationsDatabaseContext();
        }

        // Provide an accessor to the database
        public static ClientApplicationsDatabaseContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}

/*
 * Nuget Packages
 * Install-Package Microsoft.EntityFrameworkCore.Tools
 */

