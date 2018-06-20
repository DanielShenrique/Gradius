using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;

namespace Gradius
{
    class Enemy
    {
        private Paint red;
        private Bitmap inimigo;
        private float posX, posY, width, height, speedx;
		private bool ismoving, ismovingright;
        private bool coll;

        private Context  context;

		public Enemy(Bitmap image, Context c)
        {
            context = c;

            red = new Paint();
            red.SetARGB(182, 0, 0, 0);

            inimigo = image;

            posX = 900f;
            posY = 0f;

			width = inimigo.Width;
			height = inimigo.Height;

            speedx = 5f;

            ismoving = ismovingright = true;

            coll = false;
		}
        public float GetX() { return posX; }
        public float GetY() { return posY; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        public void Update(Bullet bullet)
		{
			if (ismoving)
			{
				if (ismovingright)
				{
				   posX -= speedx;
				}
			}
            CollBulle(bullet);
		}

		public void DrawImage(Canvas canvas)
        {
            if(coll == false)
                canvas.DrawBitmap(inimigo, posX , posY, red);
            else if(coll == true)
            {
                //Intent i = new Intent(context, typeof(VitoriaActivity));

                /*Bundle parameters = new Bundle();
                parameters.PutString(Intent.ExtraText, "youWin");

                i.PutExtras(parameters);*/
                //context.StartActivity(i);

            }

        }

        public void CollBulle(Bullet bullet)
        {
            if (posX < bullet.GetX() + bullet.GetW()
                && posX + inimigo.Width > bullet.GetX()
                && posY < bullet.GetY() + bullet.GetH()
                && posY + inimigo.Height > bullet.GetY())
            {
                coll = true;
                Log.Debug("TAGGGGGG", "Aaaaaaaaa");
            }
        }

	}


}
 