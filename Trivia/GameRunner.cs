﻿namespace Trivia
{
    using System;

    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(string[] args)
        {
            var rand = new Random();
            Run(rand);
        }

        public static void Run(Random rand)
        {
            var aGame = new Game();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    _notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
            }
            while (_notAWinner);
        }
    }
}
