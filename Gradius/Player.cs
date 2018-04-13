using Android.Graphics;
using Android.Views;
namespace Gradius
{
    class Player
    {
        private Paint blue;
        private float x, y, width, height, speedx;
        private bool ismoving, ismovingleft;

        public Player() {

            blue = new Paint();
            blue.SetARGB(200, 0, 0, 255);

            width = GameView.screenW * 0.2f;
        }
    }
}