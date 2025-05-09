using UnityEngine;

namespace BulletStuff
{
    public class Bullet : IBullet
    {
        public int Damage { get; set; }
        public float Speed { get; set; }

        public Bullet(int damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }

        public void Hit()
        {
            Debug.Log("Do the damage: " + Damage + " " + Speed);
        }
    }
}