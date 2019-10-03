using System;

namespace SnakeGame.Slitters
{
    public class Snake : Slitter
    {
        public Snake(Block initBlock) : base(initBlock)
        {
        }

        public override int InitSize => 5;

        protected override char BodyChar => 'O';

        protected override char HeadChar => 'X';
    }
}
