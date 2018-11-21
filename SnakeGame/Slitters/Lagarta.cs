using System.Linq;

namespace SnakeGame.Slitters
{
    public class Lagarta : Slitter
    {
        public Lagarta(Block initBlock)
            : base(initBlock)
        {
        }

        public override int InitSize => 3;

        protected override char BodyChar => 'L';

        protected override char HeadChar => 'K';

        public override bool Eat(Block feed)
        {
            var result = base.Eat(feed);

            if (result)
            {
                if (feed.Color.HasValue)
                {
                    BodyColor = feed.Color.Value;
                    Body = Body.Select(item => new Block(item.X, item.Y, item.Solid, BodyColor)).ToList();
                }
            }

            return result;
        }
    }
}