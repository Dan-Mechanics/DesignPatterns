using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryFireCommand : IWeaponCommand
{
    public void Execute(WeaponState weaponState)
    {
        // primary fire could also be called fire0 or shoot or somethimg like that
        // secndandry fire can be called alt fire.
        weaponState.DoPrimaryFire();
    }
}
