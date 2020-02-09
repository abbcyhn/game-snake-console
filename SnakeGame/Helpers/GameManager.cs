namespace SnakeGame.Helpers
{
    using System;
    using Implementations;
    using System.Threading;
    using System.Diagnostics;

    public static class GameManager
    {
        private static Food food;
        private static Snake snake;
        private static Scene scene;
        private static bool inGame = true;

        static GameManager()
        {
            int width = (int) Screen.WIDTH;
            int height = (int) Screen.HEIGHT;

            food = new Food();
            snake = new Snake(3);
            scene = new Scene(width, height);

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public static void Start()
        {
            scene.Draw();
            snake.Draw();
            food.Draw();
            Play();
        }

        private static void Play()
        {
            while(inGame)
            {
                Direction direction = GetInput();
                inGame = snake.Move(direction);

                if (snake.Eat(food))
                {
                    snake.Grow();

                    food = new Food();
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Thread.Sleep(100);
            }

            GameOver();
        }
        private static void GameOver()
        {
            CConsole.Write(35, 13, "GAME OVER!", ConsoleColor.Red);
        }
        private static Direction GetInput()
        {
            Direction direction = snake.Direction;
            if (!Console.KeyAvailable) return direction;

            ConsoleKeyInfo key = Console.ReadKey();
            //left
            if (key.Key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
                direction = Direction.LEFT;

            //right
            if (key.Key == ConsoleKey.RightArrow && direction != Direction.LEFT)
                direction = Direction.RIGHT;

            //up
            if (key.Key == ConsoleKey.UpArrow && direction != Direction.DOWN)
                direction = Direction.UP;

            //down
            if (key.Key == ConsoleKey.DownArrow && direction != Direction.UP)
                direction = Direction.DOWN;

            return direction;
        }
    }
}