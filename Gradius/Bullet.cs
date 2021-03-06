﻿using System;
using Android.Graphics;

namespace Gradius
{
    class Bullet
    {
		private Paint blue;
		private Bitmap tiro;
		private float posX, posY, width, height, speedX;
        private bool couldCollide;

		public Bullet (Player player, int numInst, int i, Bitmap image)
		{
			tiro = image;

			blue = new Paint();
			blue.SetARGB(200, 0, 0, 255);

            posX = 25f;
            posY = player.GetY();

            couldCollide = false;

            speedX = 5f;            

            width = tiro.Width;
            height = tiro.Height;
		}

        public float GetX() { return posX; }
        public float GetY() { return posY; }
        public float GetH() { return height; }
        public float GetW() { return width; }

        public void DrawImage(Canvas canvas, Bitmap image)
		{
			tiro = image;

			if (couldCollide == false)
			    canvas.DrawBitmap(tiro, posX, posY, blue);
            else
            {
                
            }
		}
		public void Update(Enemy enemy)
        {
           posX += speedX;
           CollisionWithEnemys(enemy);
        }

        void CollisionWithEnemys(Enemy enemy)
        {
            if ( posX > enemy.GetX()
                && posX + tiro.Width < enemy.GetX() + enemy.GetW() 
                && posY > enemy.GetY()
                && posY + tiro.Height > enemy.GetY() + enemy.GetH())
            {
				couldCollide = true;
				enemy.Destroy = true;
            }            
        }
    }
}