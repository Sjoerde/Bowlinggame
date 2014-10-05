using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowlinggame
{
    public class Frame
    {
        public int Throw1 { get; set; }
        public int Throw2 { get; set; }
        public int NumberOfThrows { get; set; }
        public Frame NextFrame1 { get; set; }
        public Frame NextFrame2 { get; set; }

        public int NrOfPinsThrown
        {
            get
            {
                return Throw1 + Throw2;
            }
        }

        // Frame is finished after two rolls or a strike.
        public bool IsFinished
        {
            get
            {
                return NumberOfThrows >= 2 || Throw1 == 10;
            }
        }

        public bool IsSpare
        {
            get
            {
                return NumberOfThrows >= 2 && Throw1 < 10 && Throw1 + Throw2 == 10;
            }
        }

        public bool IsStrike
        {
            get
            {
                return NumberOfThrows == 1 && Throw1 == 10;
            }
        }

        public void Roll(int pins)
        {
            if (IsFinished)
            {
                throw new Exception("After a frame is finished a new throw is not allowed.");
            }

            if (NumberOfThrows == 0) 
            {
                Throw1 = pins;
            }
            else if (NumberOfThrows == 1)
            {
                Throw2 = pins;
            }
            NumberOfThrows++;

            if (NrOfPinsThrown > 10) 
            {
                throw new Exception("More than ten pins thrown is not accepted.");
            }
        }

        public int Score()
        {
            int score = Throw1 + Throw2;
            if (IsSpare || IsStrike)
            {
                score += NextFrame1.Throw1;
            }
            if (IsStrike)
            {
                if (!NextFrame1.IsStrike)
                {
                    score += NextFrame1.Throw2;
                }
                else
                {
                    score += NextFrame2.Throw1;
                }
            }
            return score;
        }
    }
}
