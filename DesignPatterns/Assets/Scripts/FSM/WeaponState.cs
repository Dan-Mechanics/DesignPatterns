using System;
using UnityEngine;

namespace DesignPatterns
{
    public abstract class WeaponState : IState
    {
        public event Action<string> OnTransitionRequest;

        public const string READY_STATE_NAME = "ready";
        public const string RELOADING_STATE_NAME = "reloading";
        public const string TOGGLE_STATE_NAME = "toggle";

        protected InputHandler inputHandler;
        protected IWeapon weapon;
        protected AudioSource source;

        public void SetupBase(InputHandler inputHandler, IWeapon weapon, AudioSource source) 
        {
            this.inputHandler = inputHandler;
            UpdateWeapon(weapon);
            this.source = source;
        }

        public virtual void EnterState() { }
        public virtual void Update() { }
        public virtual void ExitState() { }

        public void UpdateWeapon(IWeapon weapon) => this.weapon = weapon;
        protected void TransitonTo(string name) => OnTransitionRequest?.Invoke(name);
    }
}