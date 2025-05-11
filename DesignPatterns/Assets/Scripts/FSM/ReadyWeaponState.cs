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
        private IWeapon weapon;
        
        private bool isButtonPressed;
        private float nextShootTime;
        private int bulletsLeft;
        private FixedTicks fixedTicks;

        public ReadyWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, ReloadingWeaponState reloading, IWeapon weapon) : base(fsm, inputHandler)
        {
            reloading.OnReload += Reload;
            this.weapon = weapon;
            this.fixedTicks = new FixedTicks(weapon.GetShootInterval());

            Reload();
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

            // This means that if our framerate is lesser than our shoot interval,
            // the player still does the same amount of dmg.
            for (int i = 0; i < fixedTicks.GetTicksCount(Time.deltaTime); i++)
            {
                if (isButtonPressed && Time.time >= nextShootTime && bulletsLeft > 0)
                    ShootBullet();
            }
            
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
            if (bulletsLeft >= weapon.GetMaxBullets())
                return;

            fsm.TransitionTo(typeof(ReloadingWeaponState));
        }

        public void Reload() => bulletsLeft = weapon.GetMaxBullets();

        public void ShootBullet() 
        {
            bulletsLeft--;
            nextShootTime = Time.time + weapon.GetShootInterval();
            
            Debug.Log($"Shoot !! with {weapon.GetDamage()} damage, interval = {weapon.GetShootInterval()}");
        }
    }
}