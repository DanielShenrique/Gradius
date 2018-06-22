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
		private static BulletManager instace;

		public List<Bullet> bullets;

		public float yPlayer;

		public int numInst;

		private BulletManager(Player player, Bitmap image)
		{
			numInst = 10;

			bullets = new List<Bullet>();

			InstaceBullets(player, image);
		}

		public static BulletManager getIntance(Player player, Bitmap image)
		{
			if(instace == null)
				instace = new BulletManager(player, image);

			return instace;
		}

		public void InstaceBullets(Player player, Bitmap image)
		{
			yPlayer = player.GetY();

			for(int i = 0; i < numInst; i++)
			{
				Bullet bullet = new Bullet(player, numInst, i, image);
				bullets.Add(bullet);

			}
		}
	}
}