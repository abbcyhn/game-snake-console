namespace SnakeGame.Implementations
{
    using System;
    using Abstractions;
    using SnakeGame.Helpers;

    public class Scene : IDrawable
    {
        public Scene(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Draw()
        {
            for (int x = 1; x < Width - 1; x++)
            {
                CConsole.Write(x, 0, '-', ConsoleColor.Green);
                CConsole.Write(x, Height - 1, '-', ConsoleColor.Green);
            }

            for (int y = 1; y < Height - 1; y++)
            {
                CConsole.Write(0, y, '|', ConsoleColor.Green);
                CConsole.Write(Width - 1, y, '|', ConsoleColor.Green);
            }
        }
    }
}
