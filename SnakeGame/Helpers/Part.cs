namespace SnakeGame.Helpers
{
    using Abstractions;

    public class Part : IDrawable, IRemovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public void Draw()
        {
            CConsole.Write(X, Y, Symbol);
        }
        public void Remove()
        {
            CConsole.Write(X, Y, ' ');
        }
    }
}