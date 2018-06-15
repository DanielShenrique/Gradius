using Android.Graphics;
using Android.Views;
using Android.OS;
using Android.Util;
using Android.Content;

namespace Gradius
{
    class Player
    {
        private Paint blue;
        private Bitmap nave;
        private float x, y, width, height, speedy;
        private bool ismoving, ismovingdown;
        private Context context;

        public bool coll;

        public Player(Bitmap image, Context c) {

            context = c;

            nave = image;

            x = 5f;
            y = 0f;

            width = nave.Width;
            height = nave.Height;

            speedy = 10f;
 
            ismoving = ismovingdown = false;

            blue = new Paint();
            blue.SetARGB(200, 0, 0, 255);

            coll = false;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        public void DrawImage(Canvas canvas)
        {
            if(coll == false)
                canvas.DrawBitmap(nave, x, y, blue);
            else if(coll == true)
            {
                Intent i = new Intent(context, typeof(DerrotaActivity));

                context.StartActivity(i);
            }

        }

        public void Update(Enemy enemy)
        {
            if (ismoving)
            {
                if (ismovingdown)
                {
                    //Log.Debug("CIMA", "TRUE");
                    y -= speedy;
                }
                else
                {
                    //Log.Debug("CIMA", "False");
                    y += speedy;
                }
            }
            CollisionWithScreen();
            CollisionEnemy(enemy);
        }


        void CollisionWithScreen()
        {
            if(y < 0)
            {
                y += speedy;
            }
            else if (y + width > GameView.screenW)
            {
                y -= speedy;
            }      
        }

        public void CollisionEnemy(Enemy enemy)
        {

            if (x > enemy.GetX()
                && x + nave.Width < enemy.GetX() + enemy.GetW()
                && y > enemy.GetY()
                && y + nave.Height > enemy.GetY() + enemy.GetH())
            {
                //coll = true;
            }
        }

		public void PreUpdate(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Move)
            {
                ismoving = true;
                if (y > e.RawY)
                {
                    ismovingdown = true;
                }
                else
                {
                    ismovingdown = false;
                }
            }
            else if (e.Action == MotionEventActions.Up)
                ismoving = false;
        }
    }
}