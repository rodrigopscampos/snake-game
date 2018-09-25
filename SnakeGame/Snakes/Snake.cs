using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Snake
    {
        public int InitSize { get; }
        public IEnumerable<Block> Body => _body;

        private List<Block> _body = new List<Block>();

        public Block Head => Body.Last();
        public Block Tail => Body.First();

        protected char BodyChar = '0';
        protected char HeadChar = 'X';

        public Snake(int initSize, Block initBlock)
        {
            _body = new List<Block>();
            InitSize = initSize;

            for (int i = 0; i < initSize; i++)
            {
                var block =
                    i == initSize - 1
                    ? new Block(initBlock.X, initBlock.Y + i, HeadChar)
                    : new Block(initBlock.X, initBlock.Y + i, BodyChar);

                _body.Add(block);
            }

        }

        public void Move(Direction direction)
        {
            var head = Head;
            var tail = Tail;

            switch (direction)
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
                    return;
            }

            _body.RemoveAt(0);

            var previousHead = _body[_body.Count - 1];
            previousHead.Solid = BodyChar;

            _body[_body.Count - 1] = previousHead;

            head.Solid = HeadChar;
            _body.Add(head);
        }

        public bool Eat(Block feed)
        {
            if (Head.Equals(feed))
            {
                _body.Insert(0, Tail);
                return true;
            }

            return false;
        }

        public bool BodyIsOver(Block block)
        {
            return Body.Contains(block);
        }
    }
}