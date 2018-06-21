using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Gradius
{
    public class GameView : View, IRunnable
    {
        Context context;

        public static int screenW, screenH;
        public static bool isDead, isPaused, isUpdating;

        private Player player;
        private Enemy enemy;
		private Letter letter;
		private Bullet bullet;

        //private BulletManager bm;

        private Paint white;

        private Handler handler;


        public GameView(Context context) : base(context)
        {
            Initialize(context);
        } 

        public GameView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public GameView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize(context);

        }

        private void Initialize(Context co)
        {
            context = co;

            SetBackgroundColor(Color.White);

            screenW = context.Resources.DisplayMetrics.WidthPixels;
            screenH = context.Resources.DisplayMetrics.HeightPixels;

            isDead = isPaused = false;
            isUpdating = true;

            white = new Paint();
            white.SetARGB(255, 255, 255, 255);

            player = new Player(BitmapFactory.DecodeResource(Resources, Resource.Drawable.nave_game), context);

			bullet = new Bullet(BitmapFactory.DecodeResource(Resources, Resource.Drawable.tiro), player);

			letter = new Letter(BitmapFactory.DecodeResource(Resources, Resource.Drawable.nave_game), context);

			enemy = new Enemy(BitmapFactory.DecodeResource(Resources, Resource.Drawable.inimigo), context);

            handler = new Handler();
            handler.Post(this);

			//bm = BulletManager.getInstance(bullet, player);
           
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (!isDead && !isPaused)
                player.PreUpdate(e);
            else if (isDead)
                RestartGame();
            else if (isPaused)
                isPaused = false;

            return true;
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            if (!isDead && !isPaused)
            {
                player.DrawImage(canvas);
                enemy.DrawImage(canvas);
                bullet.DrawImage(canvas);
				letter.DrawImage(canvas);
                
				/*foreach(Bullet b in bm.bullet)
				{
					b.DrawImage(canvas);
				}*/
            }
        }
        private void RestartGame()
        {
            isDead = false;
        }

        private void GameOver()
        {
        }

        private void Update()
        {
            if (!isDead && !isPaused)
            {
                player.Update(enemy);
                enemy.Update(bullet);
                bullet.Update(enemy);
				letter.Update(player);
            }
            else if (isDead)
                GameOver();
        }

		public void Run()
        {
            if (isUpdating)
            {
                handler.PostDelayed(this, 30);

                Update();
                this.Invalidate();
            }
            else
            {

            }
        }
    }
}