using System;

namespace SnakeGame
{
    public struct Block
    {
        public int X;
        public int Y;
        public char Solid;
        public ConsoleColor? Color;

        public Block(int x, int y, char solid, ConsoleColor? color = null)
        {
            X = x;
            Y = y;
            Solid = solid;
            Color = color;
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