using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletStuff
{
    public class PiercingBulletDecorator : BulletDecorator
    {
        public PiercingBulletDecorator(int damage) : base(damage) { }

        public override IBullet Decorate(IBullet bullet)
        {
            bullet.Damage *= Damage;
            return bullet;
        }
    }
}