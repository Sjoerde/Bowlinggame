using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Extensions;
using FluentAssertions;

namespace Bowlinggame.Test
{
    public class GameTests
    {
        [Theory,
         InlineData(1, 1, 2)]
        public void Roll(int roll1, int roll2, int score)
        {
            var game = new Game();
            game.Roll(roll1);
            game.Roll(roll2);

            game.Score().Should().Be(score);
        }

        [Theory,
         InlineData(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0),
         InlineData(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20),
         InlineData(new[] { 5, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 16),
         InlineData(new[] { 10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 24),
         InlineData(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300),
         InlineData(new[] { 1, 2, 3, 4, 5, 5, 6, 4, 7, 3, 8, 2, 9, 1, 10, 10, 10, 10, 8 }, 188)]
        public void Score(int[] rolls, int score)
        { 
            var game = new Game();
            foreach (int roll in rolls)
            {
                game.Roll(roll);
            }
            game.Score().Should().Be(score);
        }
    }
}
