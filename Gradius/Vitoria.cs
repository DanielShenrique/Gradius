using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Gradius
{
    class Vitoria : View
    {
        private Context context;
        private Bitmap background;
        private Paint paint;


        public Vitoria(Context context) : base(context)
        {
            Initialize(context);
        }

        public Vitoria(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public Vitoria(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize(context);
        }

        private void Initialize(Context c)
        {
            context = c;

            background = BitmapFactory.DecodeResource(Resources, Resource.Drawable.tela_de_vitoria);

            paint = new Paint();
            paint.Color = Color.Black;
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
                Intent i = new Intent(context, typeof(MainActivity));

                Bundle myParameters = new Bundle();
                myParameters.PutString(Intent.ExtraText, "You Win!!!");

                i.PutExtras(myParameters);
                context.StartActivity(i);
            }

            return true;
        }
    }
}