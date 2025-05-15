using System;

namespace DesignPatterns
{
    [Serializable]
    public class LoadoutAssembler 
    {
        public BaseWeapon baseWeapon;
        public WeaponDecorator[] weaponDecorators;

        public LoadoutAssembler(BaseWeapon baseWeapon, WeaponDecorator[] weaponDecorators)
        {
            this.baseWeapon = baseWeapon;
            this.weaponDecorators = weaponDecorators;
        }

        public IWeapon Assemble() 
        {
            IWeapon weapon = baseWeapon;

            for (int i = 0; i < weaponDecorators.Length; i++)
            {
                weapon = weaponDecorators[i].Decorate(weapon);
            }

            return weapon;
        }
    }
}