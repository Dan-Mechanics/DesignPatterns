namespace BulletStuff
{
    public interface IBullet
    {
        int Damage { get; set; }
        float Speed { get; set; }
        void Hit();
    }
}