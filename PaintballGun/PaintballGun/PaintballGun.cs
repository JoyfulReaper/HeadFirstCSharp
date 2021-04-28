using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintballGun
{
    // What is this, java?
    // LOL I know its a mess, the book takes you through a look of revisons
    // PS it is al awesome book, wish I would have found it when I was 1st 
    // starting out with C#!

    class PaintballGun
    {
        public PaintballGun(int balls, int magazineSize, bool loaded) // the bool for loaded seems to work backwards from what I expect, no idea why the author did this...
        {
            this._balls = balls; // the book has this.balls = balls, but I prefix locals with _here..
            MagazineSize = magazineSize;
            if(!loaded)
            {
                Reload();
            }
        }

        //public const int MAGAZINE_SIZE = 16;
        public int MagazineSize { get; private set; } = 16;

        private int _balls = 0;
        //private int _ballsLoaded = 0;
        public int BallsLoaded { get; private set; }

        public int Balls
        {
            get => _balls;
            set
            {
                if (value > 0)
                {
                    _balls = value;
                }
                Reload();
            }
        }

        //public int BallsLoaded { get => _ballsLoaded; set { _ballsLoaded = value; } }

        //public int GetBallsLoaded() => _ballsLoaded;

        public bool IsEmpty() => BallsLoaded == 0;

        //public int GetBalls() => balls;

        //public void SetBalls(int numberOfBalls)
        //{
        //    if(numberOfBalls > 0)
        //    {
        //        balls = numberOfBalls;
        //    }

        //    Reload();
        //}

        public void Reload()
        {
            //if(_balls > MAGAZINE_SIZE)
            //{
            //    BallsLoaded = MAGAZINE_SIZE;
            //}
            if (_balls > MagazineSize)
            {
                BallsLoaded = MagazineSize;
            }
            else
            {
                BallsLoaded = _balls;
            }
        }

        public bool Shoot()
        {
            if(BallsLoaded == 0)
            {
                return false;
            }

            BallsLoaded--;
            _balls--;

            return true;
        }
    }
}
