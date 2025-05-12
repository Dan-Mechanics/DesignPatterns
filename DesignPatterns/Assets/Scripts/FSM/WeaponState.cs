using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
    public abstract class WeaponState : IState
    {
        protected FSM<WeaponState> fsm;
        protected InputHandler inputHandler;
        protected IWeapon weapon;
        protected AudioSource source;

        protected WeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source)
        {
            this.fsm = fsm;
            this.inputHandler = inputHandler;
            //this.weapon = weapon;
            UpdateWeapon(weapon);
            this.source = source;
        }

        public virtual void EnterState() { }
        public virtual void Update() { }
        public virtual void ExitState() { }

        public void UpdateWeapon(IWeapon weapon) => this.weapon = weapon;
    }
}