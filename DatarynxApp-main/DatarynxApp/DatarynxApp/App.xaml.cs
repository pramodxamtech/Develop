using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DatarynxApp.Services;
using DatarynxApp.Views;
using System.Threading.Tasks;

namespace DatarynxApp
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            DataStorageService dataStorageService = new DataStorageService();
            Task.Run(async () => {
                 dataStorageService.StoreJsonData();
            });
            
           // DependencyService.Register<MockDataStore>();
           
            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
