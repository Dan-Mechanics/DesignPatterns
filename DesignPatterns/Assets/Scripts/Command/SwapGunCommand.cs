using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGunCommand : ICommand
{
    public void Execute() => Swap();

    public void Undo() { }

    private void Swap()
    {
        Debug.Log("Swap !!!");
    }
}
