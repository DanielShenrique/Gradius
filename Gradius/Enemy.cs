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
        public bool destroy;

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

            destroy = false;
		}
        public float GetX() { return posX; }
        public float GetY() { return posY; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        public void Update(BulletManager bullet)
		{
			if (ismoving)
			{
				if (ismovingright)
				{
				   posX -= speedx;
				}
			}
		}

		public bool Destroy
		{
			get { return destroy; }
			set { destroy = true; }
		}

		public void DrawImage(Canvas canvas)
        {
            if(!destroy)
                canvas.DrawBitmap(inimigo, posX , posY, red);
            else
            {
                //Intent i = new Intent(context, typeof(VitoriaActivity));

                /*Bundle parameters = new Bundle();
                parameters.PutString(Intent.ExtraText, "youWin");

                i.PutExtras(parameters);*/
                //context.StartActivity(i);

            }

        }
	}


}
 