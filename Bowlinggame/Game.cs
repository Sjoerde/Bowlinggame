using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowlinggame
{
    public class Game
    {
        public IList<Frame> Frames
        {
            get;
            set;
        }

        public Game() 
        {
            Frames = new List<Frame>();
        }

        public void Roll(int pins)
        {
            if (Frames.Count == 0 || Frames.Last().IsFinished)
            {
                var newFrame = new Frame();
                Frames.Add(newFrame);
                if (Frames.Count >= 2) 
                {
                    Frames[Frames.Count - 2].NextFrame1 = newFrame;
                }
                if (Frames.Count >= 3)
                {
                    Frames[Frames.Count - 3].NextFrame2 = newFrame;
                }
            }
            Frames.Last().Roll(pins);
        }

        public int Score()
        {
            return Frames.Take(10).Sum(f => f.Score());
        }
    }
}
