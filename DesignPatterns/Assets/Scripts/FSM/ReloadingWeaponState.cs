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

        public ReloadingWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(fsm, inputHandler, weapon, source)
        {
            //this.source = source;
            timer = new Timer();
        }

        public override void EnterState()
        {
            base.EnterState();
            
            timer.SetValue(weapon.GetReloadTime());
            source.PlayOneShot(weapon.GetReloadSound());
            Debug.Log($"started reloading {Time.time}");
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
            Debug.Log($"done reloading {Time.time}");
        }
    }
}