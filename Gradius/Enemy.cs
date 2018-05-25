using Android.Graphics;
using Android.Views;
using Android.OS;


namespace Gradius
{
    class Enemy
    {
        private Paint red;
        private Bitmap inimigo;
        //private float x, y, width, height;
        //private bool removed;

        public Enemy(Bitmap image)
        {

            red = new Paint();
            red.SetARGB(182, 0, 0, 0);

            inimigo = image;


            

        }

        public void DrawImage(Canvas canvas)
        {
            //canvas.DrawBitmap(inimigo, x, y, red);

        }
    }
} 