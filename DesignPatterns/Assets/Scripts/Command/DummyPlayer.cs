using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    private readonly InputHandler handler = new InputHandler();

    private void Start()
    {
        handler.Bind(KeyCode.E, new SwapGunCommand());
        var fireGunCommand = new PrimaryFireCommand();

        handler.Bind(KeyCode.Mouse0, fireGunCommand);
        handler.Bind(KeyCode.Mouse1, fireGunCommand);
    }

    private void Update()
    {
        handler.Update();
    }
}
