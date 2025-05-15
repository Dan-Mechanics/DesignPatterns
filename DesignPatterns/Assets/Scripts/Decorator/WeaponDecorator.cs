using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Reference:
    /// https://www.youtube.com/watch?v=o5Iwu5wpINQ
    /// </summary>
    public abstract class WeaponDecorator : ScriptableObject, IWeapon
    {
        protected IWeapon weapon;

        public WeaponDecorator Decorate(IWeapon weapon) 
        {
            this.weapon = weapon;
            return this;
        }

        public IWeapon GetUnderlyingWeapon() => weapon;

        public virtual float GetDamage() => weapon.GetDamage();
        public virtual float GetMaxBulletRange() => weapon.GetMaxBulletRange();
        public virtual int GetMaxBullets() => weapon.GetMaxBullets();
        public virtual float GetSpread() => weapon.GetSpread();
        public virtual string GetName() => weapon.GetName();
        public virtual AudioClip GetReloadSound() => weapon.GetReloadSound();
        public virtual float GetReloadTime() => weapon.GetReloadTime();
        public virtual float GetShootInterval() => weapon.GetShootInterval();
        public virtual AudioClip GetShootSound() => weapon.GetShootSound();
    }
}