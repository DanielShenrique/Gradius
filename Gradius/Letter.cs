using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gradius
{
	class Letter
	{
		private Paint white;
		private Bitmap letters;
		private float posX, posY, width, height, speedX;
		private bool ismoving, ismovingright;
		private bool coll;

		private Context context;

		public Letter(Bitmap image, Context c)
		{
			context = c;

			white = new Paint();
			white.SetARGB(225,225,225, 0);

			letters = image;

			posX = 500f;
			posY = 400f;

			width = letters.Width;
			height = letters.Height;

			speedX = 5f;

			ismoving = ismovingright = true;

			coll = false;
		}

		public float GetX() { return posX; }
		public float GetY() { return posY; }
		public float GetW() { return width; }
		public float GetH() { return height; }

		public void Update(Player player)
		{
			if (ismoving)
			{
				if (ismovingright)
				{
					posX -= speedX;
				}
			}
			CollLetter(player);
		}

		public void DrawImage(Canvas canvas)
		{
			if(coll == false)
			{
				canvas.DrawBitmap(letters, posX, posY, white);
			}
			else
			{
				SendLetterToHangman();
			}
		}

		private void SendLetterToHangman()
		{
            coll = false;

			Intent i = new Intent("Game");
            i = context.PackageManager.GetLaunchIntentForPackage("com.tedmrogers.launchme");

            i.AddCategory("Hangman");

			i.AddFlags(ActivityFlags.ClearTask);

			Bundle myParameters = new Bundle();
			myParameters.PutString("Letter", "en");
            myParameters.PutBoolean("GradiusWin", true);
        
			i.PutExtras(myParameters);
			context.StartActivity(i);
		}

		public void CollLetter(Player player)
		{
			if (posX < player.GetX() + player.GetW()
				&& posX + letters.Width > player.GetX()
				&& posY < player.GetY() + player.GetH()
				&& posY + letters.Height > player.GetY())
			{
				coll = true;
			}
		}
	}
}