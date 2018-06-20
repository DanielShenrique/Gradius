using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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

        public int numBullet;
    
        public List<Bullet> bullets;


        private BulletManager(Player player, Bullet bit)
        {
            numBullet = 10;

            y = player.GetY();

            bullets = new List<Bullet>();
            SetupBullet(bit, player);
        }


        public void SetupBullet(Bullet bit, Player player )
        {
            for (int i = 0; i < numBullet; i++)
            {
                Bullet bullet = new Bullet(i, bit.GetI(), player);
                bullets.Add(bullet);
            }
        }

        public static BulletManager getInstance(Bullet bit, Player player)
        {
            if (instance == null)
                instance = new BulletManager(player, bit);

            return instance;
        }

    }
}