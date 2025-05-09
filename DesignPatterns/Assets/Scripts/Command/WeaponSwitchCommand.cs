using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchCommand : IGameObjectCommand
{
    public void Execute(GameObject actor)
    {
        Debug.Log($"{actor.name} weapon switch!");
    }
}
