using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class SwapGunCommand : IWeaponCommand
    {
        public void Execute(WeaponState weaponState, IWeapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }

}