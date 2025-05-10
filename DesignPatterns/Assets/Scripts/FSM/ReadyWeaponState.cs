using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
    public class ReadyWeaponState : WeaponState
    {
        private readonly AudioSource source;
        private bool isButtonPressed;
        private float nextShootTime;

        private int bulletsLeft = 20;

        public ReadyWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, AudioSource source, ReloadingWeaponState reloading) : base(fsm, inputHandler)
        {
            this.source = source;
            reloading.OnReload += Reload;
        }

        public override void EnterState()
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
        }

        /// <summary>
        /// Or we could include a bool in a single Action,
        /// but this might be confusing. that might work to make this look cleanrin
        /// </summary>
        private void TriggerDown() { isButtonPressed = true; }

        /// <summary>
        /// you could also utilize this to make the ratatata sound start and stop instead of spawning
        /// 10000 things.
        /// </summary>
        private void TriggerUp() { isButtonPressed = false; }

        private void TryReload() 
        {
            if (bulletsLeft < 20) 
            {
                fsm.TransitionTo(typeof(ReloadingWeaponState));
            }
        }

        // Something like this:
        /*public void UpdateShooting(bool onDown) 
        {
            if (!onDown)
                return;

            // Shoot !!
        }*/

        public void Reload() 
        {
            bulletsLeft = 20;
        }

        public void ShootBullet() 
        {
            // this should come from decorated Iweapon, given via refernce.
            float interval = 0.1f;
            bulletsLeft--;
            nextShootTime = Time.time + interval;
            
            // example
            source.Play();

            float dmg = 10f;
            Debug.Log($"Shoot !! with {dmg} damage");


        }
    }
}