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
        private float x, y, width, height, speedx;
        private bool ismoving, ismovingdown;

        private float time;

        public Player(Bitmap image) {

            blue = new Paint();
            blue.SetARGB(200, 0, 0, 255);

            time = 0f;

            nave = image;

            width = GameView.screenW * 0.02f;
            height = GameView.screenH * 0.02f;

            speedx = 5f;
            ismoving = ismovingdown = false;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        public void DrawImage(Canvas canvas)
        {
            if(time <= 5)
                canvas.DrawBitmap(nave, x, y, blue);
            else
            {
               
            }

        }

        public void Update()
        {
            if (ismoving)
            {
                if (ismovingdown)
                {
                    y -= speedx;
                }
                else
                {
                    y += speedx;
                }
            }
        }


        void CollisionWithScreen()
        {
            if(y < 0)
            {
                y += speedx;
            }
            else if (y + width > GameView.screenW)
            {
                y -= speedx;
            }      
        }

        public void PreUpdate(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Move)
            {
                ismoving = true;
                time += 1;
                Log.Debug("Inhame",time + "");
                ismovingdown = x > e.RawX; //  = true || false
            }
            else if (e.Action == MotionEventActions.Up)
                ismoving = false;
        }
    }
}