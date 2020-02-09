namespace SnakeGame.Abstractions
{
    using Helpers;

    public interface IMoveable
    {
        bool Move(Direction direction);
    }
}