using System;
using UnityEngine;

namespace DesignPatterns
{
    public abstract class WeaponState : IState
    {
        public Action<string> OnTransitionRequest;

        public const string READY_STATE_NAME = "ready";
        public const string RELOADING_STATE_NAME = "ready";
        public const string TOGGLE_STATE_NAME = "ready";

    //    protected FSM<WeaponState> fsm;
        protected InputHandler inputHandler;
        protected IWeapon weapon;
        protected AudioSource source;

        /*protected WeaponState(InputHandler inputHandler, IWeapon weapon, AudioSource source)
        {
            //this.fsm = fsm;
            this.inputHandler = inputHandler;
            UpdateWeapon(weapon);
            this.source = source;
        }*/

        public WeaponState SetupBase(InputHandler inputHandler, IWeapon weapon, AudioSource source) 
        {
            this.inputHandler = inputHandler;
            UpdateWeapon(weapon);
            this.source = source;

            return this;
        }

        public virtual void EnterState() { }
        public virtual void Update() { }
        public virtual void ExitState() { }

        public void UpdateWeapon(IWeapon weapon) => this.weapon = weapon;
    }
}