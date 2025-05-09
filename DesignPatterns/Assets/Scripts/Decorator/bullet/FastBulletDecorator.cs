using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletStuff
{
    public class FastBulletDecorator : BulletDecorator
    {
        private float speed;

        public FastBulletDecorator(int damage, float speed) : base(damage)
        {
            this.speed = speed;
        }

        public override IBullet Decorate(IBullet bullet)
        {
            bullet.Damage += Damage;
            bullet.Speed += speed;
            return bullet;
        }
    }
}