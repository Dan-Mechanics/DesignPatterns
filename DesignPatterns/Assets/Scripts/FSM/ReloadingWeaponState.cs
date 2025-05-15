using System;
using UnityEngine;

namespace DesignPatterns
{
    public class ReloadingWeaponState : WeaponState
    {
        public event Action OnReload;
        private Timer timer;

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
                TransitonTo(READY_STATE_NAME);
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