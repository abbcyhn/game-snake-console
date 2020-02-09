namespace SnakeGame.Implementations
{
    using Helpers;
    using Abstractions;
    using System.Collections.Generic;

    public class Snake : IDrawable, IMoveable
    {
        public List<Part> Body { get; private set; }
        public Direction Direction { get; private set; }

        public Snake(int length)
        {
            Body = new List<Part>();
            for (int i = 1; i <= length; i++)
            {
                Part part = new Part { X = i, Y = 5, Symbol = '*' };
                Body.Add(part);
            }

            Direction = Direction.RIGHT;
        }

        public void Draw()
        {
            foreach (var part in Body)
            {
                part.Draw();
            }
        }
        public void Grow()
        {
            Part newPart = new Part();
            Part oldPart = Body[Body.Count - 1];

            switch (Direction)
            {
                case Direction.RIGHT:
                    newPart.Y = oldPart.Y;
                    newPart.X = oldPart.X + 1;
                    break;
                case Direction.LEFT:
                    newPart.Y = oldPart.Y;
                    newPart.X = oldPart.X - 1;
                    break;
                case Direction.UP:
                    newPart.Y = oldPart.Y - 1;
                    newPart.X = oldPart.X;
                    break;
                case Direction.DOWN:
                    newPart.Y = oldPart.Y + 1;
                    newPart.X = oldPart.X;
                    break;
            }
            Body.Add(newPart);
            newPart.Draw();
        }
        public bool Eat(Food food)
        {
            bool isEat = false;

            for (int i = 0; i < Body.Count; i++)
            {
                if (Body[i].X == food.Body.X && Body[i].Y == food.Body.Y)
                {
                    isEat = true;
                }
            }
            return isEat;
        }
        public bool Move(Direction direction)
        {
            Part part = Body[Body.Count - 1];

            switch (direction)
            {
                case Direction.RIGHT:
                    if (part.X >= (int)Screen.WIDTH - 1) return false;
                    MoveAnimation(part.X + 1, part.Y);
                    break;


                case Direction.LEFT:
                    if (part.X <= 0) return false;
                    MoveAnimation(part.X - 1, part.Y);
                    break;


                case Direction.UP:
                    if (part.Y <= 0) return false;
                    MoveAnimation(part.X, part.Y - 1);
                    break;


                case Direction.DOWN:
                    if (part.Y >= (int)Screen.HEIGHT - 1) return false;
                    MoveAnimation(part.X, part.Y + 1);
                    break;
            }

            Direction = direction;
            return true;
        }
        private void MoveAnimation(int x, int y)
        {
            Body[0].Remove();
            Body.RemoveAt(0);
            Part part = new Part { X = x, Y = y, Symbol = '*' };
            Body.Add(part);
            part.Draw();
        }
    }
}