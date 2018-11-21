using System;

namespace SnakeGame
{
    class Program
    {
        const int SnakeInitSize = 8;

        static Snake _snake;
        readonly static Block _initBlock = new Block(7, 7, '*');
        readonly static Block _endBlock = new Block(47, 20, '*');

        static void Main(string[] args)
        {   
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                PrintHeader();

                _snake = new Snake(SnakeInitSize, _initBlock);

                Map.Init(_initBlock, _endBlock, _snake);
                Map.PrintBorders();

                Map.Refresh();

                while (true)
                {
                    var direction = Control.ReadInputDirection();

                    var movement = new SnakeMovement(_snake, direction);
                    var isValid = movement.Validate();

                    if (!isValid)
                    {
                        PrintEndOfGameMessage();
                        Console.ReadLine();
                        break;
                    }

                    _snake.Move(direction);

                    if (_snake.Eat(Map.Food))
                    {
                        Map.NewFeed();
                    }

                    Map.Refresh();
                }
            }
        }

        static void PrintEndOfGameMessage()
        {
            Console.SetCursorPosition(0, _endBlock.Y + 5);
            Console.WriteLine("Game Over");
        }

        static void PrintHeader()
        {
            Console.WriteLine(@"
      #########################################
                  ##### SNAKE #####
      #########################################
");
        }
    }
}
