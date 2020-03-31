using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;

namespace BroomService.Droid
{
    [Activity(Label = "BroomService", Icon = "@mipmap/ic_launcher", Theme = "@style/ThemeSplashHKD", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        public static string DeepLink { get; set; }
        private static int SPLASH_TIME = 1 * 1000;// 1 seconds
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            try
            {
                new Handler().PostDelayed(() =>
                {
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    Finish();

                }, SPLASH_TIME);

            }
            catch (Exception e) { }

        }
    }
}