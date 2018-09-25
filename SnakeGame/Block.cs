namespace SnakeGame
{
    public struct Block
    {
        public int X;
        public int Y;
        public char Solid;

        public Block(int x, int y, char solid)
        {
            X = x;
            Y = y;
            Solid = solid;
        }

        public override bool Equals(object obj)
        {
            var input = (Block)obj;
            return X == input.X && Y == input.Y;
        }

        public override string ToString()
            => $"{X},{Y}";
    }
}