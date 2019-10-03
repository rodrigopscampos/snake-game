using System;

namespace SnakeGame.Slitters
{
    public class Caracol : Slitter
    {
        public Caracol(Block initBlock) : base(initBlock)
        {
        }

        public override int InitSize => 4;

        protected override char BodyChar => 'C';

        protected override char HeadChar => 'U';
    }
}
