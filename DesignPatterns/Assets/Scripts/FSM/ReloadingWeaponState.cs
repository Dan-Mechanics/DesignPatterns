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
        private readonly Timer timer;

        public ReloadingWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon) : base(fsm, inputHandler, weapon)
        {
            //this.source = source;
            timer = new Timer();
        }

        public override void EnterState()
        {
            base.EnterState();
            timer.SetValue(weapon.GetReloadTime());
        }

        public override void Update()
        {
            base.Update();

            if (timer.Tick(Time.deltaTime))
            {
                fsm.TransitionTo(typeof(ReadyWeaponState));
            }

        }

        public override void ExitState()
        {
            base.ExitState();
            OnReload?.Invoke();
        }
    }
}