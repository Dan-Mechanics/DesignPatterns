using System;
using UnityEngine;

namespace DesignPatterns
{
    public class ToggleDecoratorWeaponState : WeaponState
    {
        public event Action<IWeapon> OnNewWeapon;
        private Timer timer;
        private WeaponDecorator removableDecorator;
        private bool hasDecorated;

        public ToggleDecoratorWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(fsm, inputHandler, weapon, source) { }

        public ToggleDecoratorWeaponState Setup(WeaponDecorator removableDecorator)
        {
            this.removableDecorator = removableDecorator;
            timer = new Timer();
            return this;
        }

        public override void EnterState()
        {
            base.EnterState();
            
            timer.SetValue(weapon.GetReloadTime());
            source.PlayOneShot(weapon.GetReloadSound());
            Debug.Log($"started applying or removing decorator {Time.time}");
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

            if (!hasDecorated)
            {
                weapon = removableDecorator.Decorate(weapon);
            }
            else 
            {
                weapon = removableDecorator.GetUnderlyingWeapon();
            }

            hasDecorated = !hasDecorated;

            OnNewWeapon?.Invoke(weapon);
            Debug.Log($"done applying or removing decorator {Time.time}");
        }
    }
}