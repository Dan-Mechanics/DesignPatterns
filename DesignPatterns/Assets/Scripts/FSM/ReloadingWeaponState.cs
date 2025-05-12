using System;
using UnityEngine;

namespace DesignPatterns
{
    public class ReloadingWeaponState : WeaponState
    {
        public event Action OnReload;
        private Timer timer;

        public ReloadingWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(fsm, inputHandler, weapon, source) { }

        public ReloadingWeaponState Setup() 
        {
            timer = new Timer();
            return this;
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
                fsm.TransitionTo(typeof(ReadyWeaponState));
        }

        public override void ExitState()
        {
            base.ExitState();

            source.PlayOneShot(weapon.GetReloadSound());
            OnReload?.Invoke();
            Debug.Log($"done reloading {Time.time}");
        }
    }
}