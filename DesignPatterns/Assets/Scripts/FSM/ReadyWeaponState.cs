using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// 
    /// We could have it so that we can keep holding down the input and it keeps firing.
    /// 
    /// I could make a builder for this.
    /// </summary>
    public class ReadyWeaponState : WeaponState
    {
        private bool isTriggerHeld;
        private float nextShootTime;
        private int bulletsLeft;
        private Transform eyes;
        private GameObject prefab;

        public ReadyWeaponState(FSM<WeaponState> fsm, InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(fsm, inputHandler, weapon, source) { }

        public ReadyWeaponState Setup(ReloadingWeaponState reloading, Transform eyes, GameObject prefab) 
        {
            reloading.OnReload += Reload;
            Reload();
            this.eyes = eyes;
            this.prefab = prefab;

            return this;
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

            source.PlayOneShot(weapon.GetShootSound());

            // Example code.
            if (Physics.Raycast(eyes.position, eyes.forward, out RaycastHit hit, weapon.GetMaxBulletRange()))
            {
                // spawn an effect here.
                Debug.Log("hello");
                // !OBJECT POOL HERE
                GameObject effect = Object.Instantiate(prefab);

                effect.transform.position = hit.point;
                effect.transform.forward = hit.normal;
            }
        }
    }
}