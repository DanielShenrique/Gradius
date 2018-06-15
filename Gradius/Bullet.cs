using System;
using Android.Graphics;

namespace Gradius
{
    class Bullet
    {
		private Paint blue;
		private Bitmap tiro;
		private float posX, posY, radius, speedX;
        private bool couldCollide;

		public Bullet (Bitmap image)
		{

			blue = new Paint();
			blue.SetARGB(200, 0, 0, 255);

            posX = 40f;
            posY = 0f;

            couldCollide = false;

            radius = 5f;
            speedX = 3f;

			tiro = image;
		}

        public float GetX() { return posX; }
        public float GetY() { return posY; }
        public float GetRad() { return radius; }

        public void DrawImage(Canvas canvas)
		{
            if(couldCollide == false)
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
            }            
        }
    }
}