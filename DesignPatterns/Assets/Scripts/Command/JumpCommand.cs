using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : IGameObjectCommand
{
    public void Execute(GameObject actor)
    {
        Debug.Log($"{actor.name} has jumped!");
    }
}
