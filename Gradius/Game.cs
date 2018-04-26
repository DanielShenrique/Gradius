using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gradius
{
    [Activity(Label = "Game")]
    class Game: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;

            SetContentView(new GameView(this));

            GetIntentMessage();

        }
        private void GetIntentMessage()
        {
            Intent i = Intent;

            if (i != null)
            {
                Bundle myParameters = i.Extras;

                if (myParameters != null) Toast.MakeText(this, myParameters.GetString(Intent.ExtraText), ToastLength.Short).Show();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            GameView.isPaused = true;
            Toast.MakeText(this, "PAUSE!!!!!", ToastLength.Short).Show();
        }

        protected override void OnStop()
        {
            base.OnStop();
            GameView.isPaused = true;
            Toast.MakeText(this, "STOP!!!!!", ToastLength.Short).Show();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            GameView.isUpdating = false;
            Toast.MakeText(this, "DESTROY!!!!!", ToastLength.Short).Show();
        }
    }
}