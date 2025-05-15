using System;
using UnityEngine;

namespace DesignPatterns
{
    public class ReadyWeaponState : WeaponState
    {
        public event Action PlayInspectAnimation;
        
        private bool isTriggerHeld;
        private float nextShootTime;
        private int bulletsLeft;
        private Transform eyes;
        private GameObjectPool pool;

        public ReadyWeaponState Setup(Transform eyes, GameObjectPool pool) 
        {
            this.eyes = eyes;
            this.pool = pool;
            Reload();
            inputHandler.GetInputEvents(PlayerAction.PrimaryFire).OnChange += OnTriggerHeldChanged;

            return this;
        }

        public override void EnterState()
        {
            base.EnterState();

            nextShootTime = Time.time;
            inputHandler.GetInputEvents(PlayerAction.Reload).OnDown += TryReload;
            inputHandler.GetInputEvents(PlayerAction.SecondaryFire).OnDown += ToggleDecorator;
            inputHandler.GetInputEvents(PlayerAction.Inspect).OnDown += PlayInspectAnimation;
        }

        public override void Update()
        {
            base.Update();

            if (!CanShootBullet())
                return;

            ShootBullet();
        }

        public override void ExitState()
        {
            base.ExitState();

            inputHandler.GetInputEvents(PlayerAction.Reload).OnDown -= TryReload;
            inputHandler.GetInputEvents(PlayerAction.SecondaryFire).OnDown -= ToggleDecorator;
            inputHandler.GetInputEvents(PlayerAction.Inspect).OnDown -= PlayInspectAnimation;
        }

        private void OnTriggerHeldChanged(bool onDown) => isTriggerHeld = onDown;
        public void Reload() => bulletsLeft = weapon.GetMaxBullets();
        private void ToggleDecorator() => TransitonTo(TOGGLE_STATE_NAME);

        private void TryReload()
        {
            if (bulletsLeft >= weapon.GetMaxBullets())
                return;

            TransitonTo(RELOADING_STATE_NAME);
        }

        private bool CanShootBullet()
        {
            return isTriggerHeld && Time.time >= nextShootTime && bulletsLeft > 0;
        }

        private void ShootBullet()
        {
            bulletsLeft--;
            nextShootTime = Time.time + weapon.GetShootInterval();

            Debug.Log($"shooting {weapon.GetName()} with {weapon.GetDamage()} damage | ({bulletsLeft}/{weapon.GetMaxBullets()}) bullets left");
            source.PlayOneShot(weapon.GetShootSound());

            if (!Physics.Raycast(eyes.position, GetShootingDirection(), out RaycastHit hit, weapon.GetMaxBulletRange()))
                return;

            hit.transform.GetComponent<IDamagable>()?.Damage(weapon.GetDamage());

            GameObject effect = pool.GetFromPool();
            effect.transform.position = hit.point;
            effect.transform.forward = hit.normal;
        }

        private Vector3 GetShootingDirection() 
        {
            Vector3 dir = eyes.forward;
            Vector2 rand = UnityEngine.Random.insideUnitCircle;
            dir += rand.y * weapon.GetSpread() * eyes.up;
            dir += rand.x * weapon.GetSpread() * eyes.right;

            return dir;
        }
    }
}