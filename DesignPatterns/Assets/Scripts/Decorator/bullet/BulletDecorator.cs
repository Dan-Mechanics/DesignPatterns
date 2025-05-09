namespace BulletStuff
{
    public abstract class BulletDecorator
    {
        public int Damage { get; set; }

        public BulletDecorator(int damage)
        {
            Damage = damage;
        }

        public abstract IBullet Decorate(IBullet bullet);
    }
}