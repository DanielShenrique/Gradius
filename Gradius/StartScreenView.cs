using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;

namespace Gradius
{
    class StartScreenView : View
    {
        private Context context;

        private Bitmap background;
        private Paint paint;

        public StartScreenView(Context context) : base(context)
        {
            Initialize(context);
        }

        public StartScreenView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public StartScreenView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize(context);
        }

        private void Initialize(Context c)
        {
            context = c;
            background = BitmapFactory.DecodeResource(Resources, Resource.Drawable.gradius_inicio);
            paint = new Paint();
            paint.Color = Color.White;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawBitmap(background, 0, 0, paint);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
            {
                Intent i = new Intent(context, typeof(Game));

                Bundle myParameters = new Bundle();
                myParameters.PutString(Intent.ExtraText, "Let's Go!!!");

                i.PutExtras(myParameters);
                context.StartActivity(i);
            }

            return true;
        }
    }
}