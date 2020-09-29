using Android.App;
using Android.Content.PM;
using Android.OS;

namespace DatarynxApp.Droid
{
    [Activity(Label = "DatarynxApp", Icon = "@drawable/MasterImage", Theme = "@style/Theme.Splash", MainLauncher = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
         
            StartActivity(typeof(MainActivity));
        }
    }
}