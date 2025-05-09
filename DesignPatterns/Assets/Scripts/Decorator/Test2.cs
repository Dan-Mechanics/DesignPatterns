using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletStuff;
using BehaviourChainConcept;
using System.Text;

namespace Bomb
{
    public class Test2 : MonoBehaviour
    {
        private void Start()
        {
            ISpell someSpell = new Spell(5);

            FireDecorator fireDecorator = new FireDecorator(20);
            someSpell = fireDecorator.Decorate(someSpell);

            IceDecorator iceDecorator = new IceDecorator(10);
            someSpell = iceDecorator.Decorate(someSpell);

            someSpell.Cast();

            // ================================

            IBullet bullet = new Bullet(5, 5f);

            FastBulletDecorator fastBulletDecorator = new FastBulletDecorator(20, 10f);
            bullet = fastBulletDecorator.Decorate(bullet);

            PiercingBulletDecorator piercingBulletDecorator = new PiercingBulletDecorator(3);
            bullet = piercingBulletDecorator.Decorate(bullet);

            bullet.Hit();
        }
    }
}