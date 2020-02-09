namespace SnakeGame.Implementations
{
    using System;
    using Abstractions;
    using SnakeGame.Helpers;

    public class Food
    {
        public Food()
        {
            Body = new Part { Symbol = '&' };
            Random rnd = new Random();
            Body.X = rnd.Next(1, (int)Screen.WIDTH - 5);
            Body.Y = rnd.Next(1, (int)Screen.HEIGHT - 5);
        }

        public Part Body { get; private set; }

        public void Draw()
        {
            CConsole.Write(Body.X, Body.Y, Body.Symbol);
        }
    }
}