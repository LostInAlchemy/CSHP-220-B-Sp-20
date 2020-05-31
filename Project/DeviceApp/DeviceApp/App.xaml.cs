using System.Windows;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Repository.DeviceRepository deviceRepository;
        private static Repository.TypeRepository typeRepository;

        static App()
        {
            deviceRepository = new Repository.DeviceRepository();
            typeRepository = new Repository.TypeRepository();
        }

        public static Repository.DeviceRepository DeviceRepository
        {
            get
            {
                return deviceRepository;
            }
        }

        public static Repository.TypeRepository TypeRepository
        {
            get
            {
                return typeRepository;
            }
        }
    }
}
