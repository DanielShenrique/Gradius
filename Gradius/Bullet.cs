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

            posX = 15f;
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
           posX -= speedX;
           CollisionWithEnemys(enemy);
        }

        void CollisionWithEnemys(Enemy enemy)
        {
            if ( posX - radius < enemy.GetX() + enemy.GetW() 
                && posX + radius > enemy.GetX() 
                && posY - radius < enemy.GetY() + enemy.GetH() 
                && posY+ radius > enemy.GetY())
            {
                couldCollide = true;
            }            
        }
    }
}