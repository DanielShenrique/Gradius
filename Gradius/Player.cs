﻿using Android.Graphics;
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


        private void Initialize(Context c)
        {
            context = c;

            blue = new Paint();
            blue.SetARGB(200, 0, 0, 255);

            coll = false;
        }


        public Player(Bitmap image) {

            nave = image;

            x = 5f; 

            width = GameView.screenW * 0.02f;
            height = GameView.screenH * 0.02f;

            speedy = 5f;
 

            ismoving = ismovingdown = false;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetW() { return width; }
        public float GetH() { return height; }

        public void DrawImage(Canvas canvas)
        {
            if(coll == false)
                canvas.DrawBitmap(nave, x, y, blue);
            else
            {
                Intent i = new Intent(context, typeof(DerrotaActivity));

                /*Bundle myParameters = new Bundle();
                myParameters.PutString(Intent.ExtraText, "Noooo");
           
                i.PutExtras(myParameters);*/
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

            if (x < enemy.GetX() + enemy.GetH()
                && x + (width + height) > enemy.GetX()
                && y - (width + height) < enemy.GetY() + enemy.GetW()
                && y + (width + height) > enemy.GetY())
            {
                coll = true;
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