using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
    public class ReloadingWeaponState : WeaponState
    {
        public event Action OnReload;
        
        private readonly AudioSource source;
        private readonly Timer timer = new Timer();

        public ReloadingWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, AudioSource source) : base(fsm, inputHandler)
        {
            this.source = source;
        }

        /*public override void EnterState()
        {
            base.EnterState();

            isButtonPressed = false;
            nextShootTime = Time.time;
            inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnDown += TriggerDown;
            inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnUp += TriggerUp;
            inputHandler.GetInputPair(PlayerAction.Reload).OnDown += TryReload;
        }

        public override void Update()
        {
            base.Update();

            if (isButtonPressed && Time.time >= nextShootTime && bulletsLeft > 0)
                ShootBullet();

        }

        public override void ExitState()
        {
            base.ExitState();

            isButtonPressed = false;

            inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnDown -= TriggerDown;
            inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnUp -= TriggerUp;
            inputHandler.GetInputPair(PlayerAction.Reload).OnDown -= TryReload;
        }*/
    }
}