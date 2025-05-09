using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunCommand : ICommand
{
    public void Execute() => Fire();

    public void Undo() { }

    private void Fire()
    {
        Debug.Log("RATATA !!!");
    }
}
