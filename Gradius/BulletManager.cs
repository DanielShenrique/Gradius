using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gradius
{
    class BulletManager
    {
        private static BulletManager instance;
        private float y;
    
        public List<Bullet> bullets;


        private BulletManager(Player player)
        {
            y = player.GetY();

            bullets = new List<Bullet>();
        }


    }
}