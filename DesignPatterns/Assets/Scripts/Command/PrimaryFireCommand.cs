using DesignPatterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class PrimaryFireCommand : IWeaponCommand
    {
        public void Execute(WeaponState weaponState, IWeapon weapon)
        {
            // primary fire could also be called fire0 or shoot or somethimg like that
            // secndandry fire can be called alt fire.
            weaponState.DoPrimaryFire(weapon);
        }
    }
}