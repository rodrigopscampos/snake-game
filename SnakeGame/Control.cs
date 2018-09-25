using System;

namespace SnakeGame
{
    public static class Control
    {
        public static Direction ReadInputDirection()
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;

                case ConsoleKey.DownArrow:
                    return Direction.Down;

                case ConsoleKey.LeftArrow:
                    return Direction.Left;

                case ConsoleKey.RightArrow:
                    return Direction.Right;

                default:
                    return Direction.Invalid;
            }
        }
    }
}
