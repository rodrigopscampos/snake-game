using System;

namespace SnakeGame
{
    public class Map
    {
        static Random _random = new Random();

        public const char BorderChar = '*';

        public static Block InitBlock { get; private set; }
        public static Block EndBlock { get; private set; }

        public static Block Food { get; private set; }

        public static Snake Snake { get; private set; }

        public static void Init(Block initBlock, Block endBlock, Snake snake)
        {
            InitBlock = initBlock;
            EndBlock = endBlock;
            Snake = snake;

            NewFeed();
        }

        public static void Refresh()
        {
            Clean();
            PrintBorders();

            foreach (var block in Snake.Body)
            {
                Console.SetCursorPosition(block.X, block.Y);
                Console.Write(block.Solid);
            }

            Console.SetCursorPosition(Food.X, Food.Y);
            Console.Write(Food.Solid);
        }

        public static void PrintBorders()
        {
            for (int x = InitBlock.X; x < EndBlock.X; x++)
            {
                Console.SetCursorPosition(x, InitBlock.Y - 1);
                Console.Write(BorderChar);

                Console.SetCursorPosition(x, EndBlock.Y);
                Console.Write(BorderChar);
            }

            for (int y = InitBlock.Y; y < EndBlock.Y; y++)
            {
                Console.SetCursorPosition(InitBlock.X - 1, y);
                Console.Write(BorderChar);

                Console.SetCursorPosition(EndBlock.X, y);
                Console.Write(BorderChar);
            }
        }

        private static void Clean()
        {
            foreach (var block in Snake.Body)
            {
                Console.SetCursorPosition(block.X, block.Y);
                Console.Write(' ');
            }

            Console.SetCursorPosition(Snake.OldTail.X, Snake.OldTail.Y);
            Console.Write(' ');

            Console.SetCursorPosition(Food.X, Food.Y);
            Console.Write(' ');
        }

        public static void NewFeed()
        {
            Block block;

            do
            {
                var x = _random.Next(InitBlock.X + 1, EndBlock.X);
                var y = _random.Next(InitBlock.Y + 1, EndBlock.Y);

                block = new Block(x, y, 'C');
            }
            while (Snake.BodyIsOver(block));

            Food = block;
        }
    }
}
