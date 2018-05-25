using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace Gradius
{
    public class GameView : View, IRunnable
    {
        Context context;

        public static int screenW, screenH;
        public static bool isDead, isPaused, isUpdating;

        private Player player;

        private Paint white;

        private Handler handler;

        private int highScore;

        private DataStorage dt;


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

            player = new Player(BitmapFactory.DecodeResource(Resources, Resource.Drawable.nave_game));


            handler = new Handler();
            handler.Post(this);

            dt = new DataStorage(context);
            highScore = dt.GetHighScore();
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

                //canvas.DrawText("High score: " + highScore.ToString(), screenW * 0.65f, screenH * 0.03f, white);
            }
            else
                canvas.DrawText("Touch to restart", screenW * 0.2f, screenH * 0.5f, white);
        }
        private void RestartGame()
        {
            player.GetX();
            isDead = false;
        }

        private void GameOver()
        {
        }

        private void Update()
        {
            if (!isDead && !isPaused)
            {
                player.Update();
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