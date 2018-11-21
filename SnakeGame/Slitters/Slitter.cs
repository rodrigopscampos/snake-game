using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public abstract class Slitter
    {
        public abstract int InitSize { get; }
        public List<Block> Body { get; set; } = new List<Block>();

        public Block OldTail;

        public Block Head => Body.Last();
        public Block Tail => Body.First();

        protected abstract char BodyChar { get; }
        protected abstract char HeadChar { get; }

        protected virtual ConsoleColor BodyColor { get; set; } = ConsoleColor.White;
        protected virtual ConsoleColor HeadColor { get; set; } = ConsoleColor.White;

        public Slitter(Block initBlock)
        {
            Body = new List<Block>();
            for (int i = 0; i < InitSize; i++)
            {
                var block =
                    i == InitSize - 1
                    ? new Block(initBlock.X, initBlock.Y + i, HeadChar, HeadColor)
                    : new Block(initBlock.X, initBlock.Y + i, BodyChar, BodyColor);

                Body.Add(block);
            }
        }

        public virtual void Move(Direction direction)
        {
            OldTail = Tail;

            var head = Head;

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

            Body.RemoveAt(0);

            var previousHead = Body[Body.Count - 1];
            previousHead.Solid = BodyChar;

            Body[Body.Count - 1] = previousHead;

            head.Solid = HeadChar;
            Body.Add(head);
        }

        public virtual bool Eat(Block feed)
        {
            if (Head.Equals(feed))
            {
                Body.Insert(0, Tail);
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