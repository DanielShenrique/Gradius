using Android.App;
using Android.Widget;
using Android.OS;

namespace Gradius
{
    [Activity(Label = "Gradius", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;

            // Set our view from the "main" layout resource
            SetContentView(new StartScreenView(this));
        }
    }
}

