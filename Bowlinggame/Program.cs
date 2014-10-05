using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowlinggame
{
    public class BowlingKata
    {
        static void Main(string[] args)
        {
            var frame = new Frame()
            {
                Throw1 = 2,
                Throw2 = 8,
                NextFrame1 = new Frame()
                {
                    Throw1 = 6,
                    Throw2 = 3
                }
            };
            var score = frame.Score();
        }
    }
}
