using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Note to sefl: we do need to give a reference to inputhandler to the states.
    /// so they can implemetn that in their own shit, or we say 
    /// 
    /// Or call it player, or something like weaponassemlber, given that loadout.
    /// </summary>
    public class PlayerContext : MonoBehaviour
    {
        [Header("Bindings")]
        [Tooltip("This should come from config file.")]
        [SerializeField] private List<InputHandler.Binding> bindings = default;

        [Header("Weapon")]
        [SerializeField] private BaseWeapon baseWeapon = default;
        [SerializeField] private WeaponDecorator removableDecorator = default;

        /// <summary>
        /// You could send this somewhere elsel ike loadoutassembler or something.
        /// </summary>
        [Tooltip("The player assembles this before the game starts.")]
        [SerializeField] private List<WeaponDecorator> weaponDecorators = default;

        [Header("References")]
        [SerializeField] private GameObject bulletImpactEffect = default;
        [SerializeField] private Transform eyes = default;
        [SerializeField] private AudioSource source = default;

        private readonly FSM<WeaponState> fsm = new FSM<WeaponState>();
        private InputHandler inputHandler;
        private GameObjectPool pool;

        private void Start()
        {
            IWeapon weapon = AssembleWeapon();
            inputHandler = new InputHandler(bindings);
            pool = new GameObjectPool(bulletImpactEffect);
            SetupStates(weapon);
        }

        private void Update()
        {
            inputHandler.Update();
            fsm.Update();
        }

        private IWeapon AssembleWeapon()
        {
            IWeapon weapon = baseWeapon;

            for (int i = 0; i < weaponDecorators.Count; i++)
            {
                weapon = weaponDecorators[i].Decorate(weapon);
            }

            return weapon;
        }

        private void SetupStates(IWeapon weapon)
        {
            var reloading = new ReloadingWeaponState(fsm, inputHandler, weapon, source).Setup();
            var toggle = new ToggleDecoratorWeaponState(fsm, inputHandler, weapon, source).Setup(removableDecorator);
            var ready = new ReadyWeaponState(fsm, inputHandler, weapon, source).Setup(eyes, pool);

            reloading.OnReload += ready.Reload;

            fsm.AddState(reloading);
            fsm.AddState(toggle);
            fsm.AddState(ready);

            fsm.GetStates().ForEach(x => toggle.OnNewWeapon += x.UpdateWeapon);

            fsm.TransitionTo(ready);
        }
    }
}