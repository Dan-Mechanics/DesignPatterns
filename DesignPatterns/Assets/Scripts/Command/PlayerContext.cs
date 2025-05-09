using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class PlayerContext : MonoBehaviour
    {
        private readonly InputHandler handler = new InputHandler();

        private readonly FSM<WeaponState> fsm = new FSM<WeaponState>();

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
}