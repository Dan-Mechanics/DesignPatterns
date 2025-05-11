using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
    public class ReadyWeaponState : WeaponState
    {
        private bool isTriggerHeld;
        private float nextShootTime;
        private int bulletsLeft;
        private Transform eyes;
        private LayerMask mask;

        public ReadyWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, ReloadingWeaponState reloading, Transform eyes) : base(fsm, inputHandler, weapon)
        {
            reloading.OnReload += Reload;
            //this.weapon = weapon;
            Reload();
            this.eyes = eyes;
            mask = LayerMask.NameToLayer("Default");
        }

        public override void EnterState()
        {
            base.EnterState();

            isTriggerHeld = false;
            nextShootTime = Time.time;

            inputHandler.GetInputEvents(PlayerAction.PrimaryFire).OnChange += OnTriggerHeldChanged;
            //inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnUp += TriggerUp;
            inputHandler.GetInputEvents(PlayerAction.Reload).OnDown += TryReload;
        }

        public override void Update()
        {
            base.Update();
            //Debug.Log($"{isButtonPressed} && {Time.time >= nextShootTime} && {bulletsLeft > 0}");
            if (isTriggerHeld && Time.time >= nextShootTime && bulletsLeft > 0)
                ShootBullet();
        }

        public override void ExitState()
        {
            base.ExitState();

            isTriggerHeld = false;

            inputHandler.GetInputEvents(PlayerAction.PrimaryFire).OnChange -= OnTriggerHeldChanged;
            //inputHandler.GetInputPair(PlayerAction.PrimaryFire).OnUp -= TriggerUp;
            inputHandler.GetInputEvents(PlayerAction.Reload).OnDown -= TryReload;
        }

        /// <summary>
        /// Or we could include a bool in a single Action,
        /// but this might be confusing. that might work to make this look cleanrin
        /// </summary>
        private void OnTriggerHeldChanged(bool onDown) => isTriggerHeld = onDown;

        /// <summary>
        /// you could also utilize this to make the ratatata sound start and stop instead of spawning
        /// 10000 things.
        /// </summary>
        //private void TriggerUp() { isTriggerHeld = false; }

        private void TryReload()
        {
            if (bulletsLeft >= weapon.GetMaxBullets())
                return;

            fsm.TransitionTo(typeof(ReloadingWeaponState));
        }

        private void Reload() => bulletsLeft = weapon.GetMaxBullets();

        public void ShootBullet() 
        {
            bulletsLeft--;
            nextShootTime = Time.time + weapon.GetShootInterval();
            
            Debug.Log($"shooting {weapon.GetName()} with {weapon.GetDamage()} damage | ({bulletsLeft}/{weapon.GetMaxBullets()}) bullets left");

            // Example code.
            if (Physics.Raycast(eyes.position, eyes.forward, out RaycastHit hit, weapon.GetMaxBulletRange(), mask, QueryTriggerInteraction.Ignore))
            {
                // spawn an effect here.

                // !OBJECT POOL HERE
                GameObject effect = Object.Instantiate(new GameObject());

                effect.transform.position = hit.point;
                effect.transform.forward = hit.normal;
            }
        }
    }
}