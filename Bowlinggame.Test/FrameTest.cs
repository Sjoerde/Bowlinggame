using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;
using FluentAssertions;
using Xunit;

namespace Bowlinggame.Test
{
    public class FrameTest
    {
        [Theory,
         InlineData(new[] { 1 }, 1, 1, false),
         InlineData(new[] { 10 }, 12, 1, true),
         InlineData(new[] { 1, 6 }, 7, 2, true)]
        public void TestRoll(int[] rolls, int score, int nrOfThrows, bool isFinished) 
        {
            var frame = new Frame()
            {
                NextFrame1 = new Frame
                {
                    Throw1 = 1,
                    Throw2 = 1
                }
            };
            foreach (var roll in rolls)
            {
                frame.Roll(roll);
            }
            frame.Score().Should().Be(score);
            frame.NumberOfThrows.Should().Be(nrOfThrows);
            frame.IsFinished.Should().Be(isFinished);
        }

        [Fact]
        public void TestRollNotAllowed()
        {
            var frame = new Frame();
            frame.Roll(10);

            var ex = Assert.Throws<Exception>(() => frame.Roll(1));

            ex.Message.Should().Be("After a frame is finished a new throw is not allowed.");
        }

        [Fact]
        public void TestRollMoreThan10PinsNotAllowed()
        {
            var frame = new Frame();
            frame.Roll(6);

            var ex = Assert.Throws<Exception>(() => frame.Roll(8));

            ex.Message.Should().Be("More than ten pins thrown is not accepted.");
        }

        [Fact]
        public void TestScore()
        {
            var frame = new Frame();
            frame.Roll(2);
            frame.Roll(3);
            frame.NextFrame1 = new Frame();
            frame.NextFrame1.Roll(6);
            frame.NextFrame1.Roll(3);

            frame.Score().Should().Be(5);
        }

        [Fact]
        public void TestScoreSpare()
        {
            var frame = new Frame();
            frame.Roll(2);
            frame.Roll(8);
            frame.NextFrame1 = new Frame();
            frame.NextFrame1.Roll(6);
            frame.NextFrame1.Roll(3);

            frame.Score().Should().Be(16);
        }

        [Fact]
        public void TestScoreStrike()
        {
            var frame = new Frame();
            frame.Roll(10);
            frame.NextFrame1 = new Frame();
            frame.NextFrame1.Roll(6);
            frame.NextFrame1.Roll(3);

            frame.Score().Should().Be(19);
        }

        [Fact]
        public void TestScoreStrike2()
        {
            var frame = new Frame();
            frame.Roll(10);
            frame.NextFrame1 = new Frame();
            frame.NextFrame1.Roll(10);
            frame.NextFrame2 = new Frame();
            frame.NextFrame2.Roll(6);

            frame.Score().Should().Be(26);
        }
    }
}
