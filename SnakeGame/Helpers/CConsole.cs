namespace SnakeGame.Helpers
{
    using System;

    public static class CConsole
    {
        public static void Write(int x, int y, char output, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(output);
        }

        public static void Write(int x, int y, string output, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(output);
        }
    }
}