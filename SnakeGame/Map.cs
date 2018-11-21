using SnakeGame.Slitters;
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

        public static Slitter Snake { get; private set; }

        public static void Init(Block initBlock, Block endBlock, Slitter snake)
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
                WriteBlock(block);
            }

            WriteBlock(Food);
        }

        static void WriteBlock(Block block)
        {
            Console.SetCursorPosition(block.X, block.Y);

            if (block.Color.HasValue && Console.ForegroundColor != block.Color.Value)
                Console.ForegroundColor = block.Color.Value;

            Console.Write(block.Solid);

            Console.ResetColor();
        }

        public static void PrintBorders()
        {
            for (int x = InitBlock.X; x < EndBlock.X; x++)
            {
                WriteBlock(new Block(x, InitBlock.Y - 1, BorderChar));
                WriteBlock(new Block(x, EndBlock.Y, BorderChar));
            }

            for (int y = InitBlock.Y; y < EndBlock.Y; y++)
            {
                WriteBlock(new Block(InitBlock.X - 1, y, BorderChar));
                WriteBlock(new Block(EndBlock.X, y, BorderChar));
            }
        }

        private static void Clean()
        {
            foreach (var block in Snake.Body)
            {
                WriteBlock(new Block(block.X, block.Y, ' '));
            }

            WriteBlock(new Block(Snake.OldTail.X, Snake.OldTail.Y, ' '));
            WriteBlock(new Block(Food.X, Food.Y, ' '));
        }

        public static void NewFeed()
        {
            Block block;

            do
            {
                var x = _random.Next(InitBlock.X + 1, EndBlock.X);
                var y = _random.Next(InitBlock.Y + 1, EndBlock.Y);

                block = new Block(x, y, 'F', ConsoleColor.DarkGreen);
            }
            while (Snake.BodyIsOver(block));

            Food = block;
        }
    }
}
