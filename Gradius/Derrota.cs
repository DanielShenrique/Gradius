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
    class Derrota : View 
    {
        private Context context;
        private Bitmap background;
        private Paint paint;


        public Derrota(Context context) : base(context)
        {
            Initialize(context);
        }

        public Derrota(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public Derrota(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize(context);
        }

        private void Initialize(Context c)
        {
            context = c;

            background = BitmapFactory.DecodeResource(Resources, Resource.Drawable.gradius_inicio);

        }
    }
}