using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// 
    /// We could have it so that we can keep holding down the input and it keeps firing.
    /// 
    /// I could make a builder for this ?
    /// </summary>
    public class ReadyWeaponState : WeaponState
    {
        private bool isTriggerHeld;
        private float nextShootTime;
        private int bulletsLeft;
        private Transform eyes;
        private GameObjectPool pool;

     //   public ReadyWeaponState(InputHandler inputHandler, IWeapon weapon, AudioSource source) : base(inputHandler, weapon, source) { }

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
        }

        public override void Update()
        {
            base.Update();

            if (!CanShootBullet())
                return;

            ShootBullet();
        }

        private bool CanShootBullet()
        {
            return isTriggerHeld && Time.time >= nextShootTime && bulletsLeft > 0;
        }

        public override void ExitState()
        {
            base.ExitState();

            inputHandler.GetInputEvents(PlayerAction.Reload).OnDown -= TryReload;
            inputHandler.GetInputEvents(PlayerAction.SecondaryFire).OnDown -= ToggleDecorator;
        }

        private void OnTriggerHeldChanged(bool onDown) => isTriggerHeld = onDown;

        private void TryReload()
        {
            if (bulletsLeft >= weapon.GetMaxBullets())
                return;

            OnTransitionRequest?.Invoke(RELOADING_STATE_NAME);
        }

        public void Reload() => bulletsLeft = weapon.GetMaxBullets();
        private void ToggleDecorator() => OnTransitionRequest?.Invoke(TOGGLE_STATE_NAME);

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
            Vector2 rand = Random.insideUnitCircle;
            dir += rand.y * weapon.GetSpread() * eyes.up;
            dir += rand.x * weapon.GetSpread() * eyes.right;

            return dir;
        }
    }
}