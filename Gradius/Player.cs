using Android.Graphics;
using Android.Views;
namespace Gradius
{
    class Player
    {
        private Paint blue;
        private float x, y, width, height, speedx;
        private bool ismoving, ismovingleft;

        public Player() {

            blue = new Paint();
            blue.SetARGB(200, 0, 0, 255);

            width = GameView.screenW * 0.02f;
            height = GameView.screenH * 0.02f;

            speedx = 5f;
            ismoving = ismovingleft = false;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        void DrawImage(Canvas canvas)
        {
            canvas.DrawRect(x, y, x + width, y + width, blue);
        }

        void Update()
        {
            if (ismoving)
            {
                if (ismovingleft)
                {
                    x -= speedx;
                }
                else
                {
                    x += speedx;
                }
            }
        }


        void CollisionWithScreen()
        {
            if(x < 0)
            {
                x += speedx;
            }
            else if (x + width > GameView.screenW)
            {
                x -= speedx;
            }      
        }

        public void PreUpdate(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down ||
               e.Action == MotionEventActions.Move)
            {
                ismoving = true;
                ismovingleft = x > e.RawX; // x = true || false
            }
            else if (e.Action == MotionEventActions.Up)
                ismoving = false;
        }
    }
}