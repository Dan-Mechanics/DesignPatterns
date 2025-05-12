using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
    public class ToggleDecoratorWeaponState : WeaponState
    {
        public event Action<IWeapon> OnNewWeapon;
        private Timer timer;
        private WeaponDecorator decorator;
        private bool hasDecorated;

        public ToggleDecoratorWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(fsm, inputHandler, weapon, source) { }

        public ToggleDecoratorWeaponState Setup(WeaponDecorator decorator)
        {
            this.decorator = decorator;
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
          //  weapon = hasDecorated ? decorator.Decorate(null) : decorator.Decorate(weapon);
           // hasDecorated = !hasDecorated;

            if (!hasDecorated)
            {
                weapon = decorator.Decorate(weapon);
            }
            else 
            {
                weapon = decorator.GetUnderlyingWeapon();
            }

            hasDecorated = !hasDecorated;

            OnNewWeapon?.Invoke(weapon);
            Debug.Log($"done applying or removing decorator {Time.time}");
        }
    }
}