using System.Linq;

namespace SnakeGame
{
    public class SnakeMovement
    {
        readonly Snake _snake;
        readonly Direction _direction;

        public SnakeMovement(Snake snake, Direction direction)
        {
            _snake = snake;
            _direction = direction;
        }

        public bool Validate()
        {
            var head = _snake.Head;
            var tail = _snake.Tail;

            switch (_direction)
            {
                case Direction.Up:

                    --head.Y;
                    break;

                case Direction.Down:

                    ++head.Y;
                    break;

                case Direction.Left:

                    --head.X;
                    break;

                case Direction.Right:

                    ++head.X;
                    break;

                default:
                    return false;
            }

            var initBlock = Map.InitBlock;
            var endBlock = Map.EndBlock;

            var result =
                    head.X < endBlock.X && head.X >= initBlock.X
                 && head.Y < endBlock.Y && head.Y >= initBlock.Y
                 && (!_snake.Body.Contains(head) || head.Equals(_snake.Tail));

            return result;
        }
    }
}
