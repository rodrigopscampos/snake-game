using SnakeGame.Slitters;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static Slitter[] _slitters;

        const int SnakeInitSize = 8;

        static Slitter _snake;
        readonly static Block _initBlock = new Block(7, 7, '*');
        readonly static Block _endBlock = new Block(47, 20, '*');

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                PrintHeader();

                _slitters = new[]
                {
                    (Slitter)new Lagarta(_initBlock),
                    (Slitter)new Snake(_initBlock),
                    (Slitter)new Caracol(_initBlock),
                };

                Console.WriteLine("Escolha um dos animais:");

                for (int i = 0; i < _slitters.Length; i++)
                {
                    Console.WriteLine(string.Format("{0, 3} - {1}", i, _slitters[i].GetType().Name));
                }

                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao >= _slitters.Length)
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                }

                _snake = _slitters[opcao];

                Console.Clear();
                PrintHeader();

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
            Console.WriteLine("Fim de jogo");
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
