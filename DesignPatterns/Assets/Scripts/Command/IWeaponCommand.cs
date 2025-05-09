using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public interface IWeaponCommand
    {
        void Execute(WeaponState weaponState, IWeapon weapon);
    }

}