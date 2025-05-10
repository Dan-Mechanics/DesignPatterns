using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
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

        public virtual float GetDamage() => weapon.GetDamage();
        public virtual int GetMaxBullets() => weapon.GetMaxBullets();
        public virtual string GetName() => weapon.GetName();
        public virtual float GetReloadTime() => weapon.GetReloadTime();
        public virtual float GetShootInterval() => weapon.GetShootInterval();
    }
}