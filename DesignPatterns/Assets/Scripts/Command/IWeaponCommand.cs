using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponCommand
{
    void Execute(WeaponState weaponState);
}
