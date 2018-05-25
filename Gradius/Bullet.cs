using Android.Graphics;

namespace Gradius
{
    class Bullet
    {
        private Paint yellow;
        private float x, y, radius, speedX;

        public void Ball()
        {
            yellow = new Paint();
            yellow.SetARGB(222, 162, 0, 0);

            x = GameView.screenW / 2;
            y = GameView.screenH / 2;

            radius = GameView.screenW * 0.04f;
            speedX = 6;

        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawCircle(x, y, radius, yellow);
        }

        public void Update(Player player)
        {
            x += speedX;
        }

        void CollisionWithScreen()
        {
            if (x + radius > GameView.screenW)
            {
                Destroy();
            }
        }

        void CollisionWithEnemys()
        {
            


        }


        void Destroy() {
            Draw(null);
        }
    }
}