using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Note: this script is the context and is therefore the least reusable.
    /// </summary>
    public class PlayerContext : MonoBehaviour
    {
        [Header("Bindings")]
        [Tooltip("This should come from config file.")]
        [SerializeField] private List<InputHandler.Binding> bindings = default;

        [Header("Weapon")]
        [SerializeField] private BaseWeapon baseWeapon = default;
        [SerializeField] private WeaponDecorator removableDecorator = default;
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
            if (baseWeapon == null || removableDecorator == null)
            {
                Debug.LogError(" if (baseWeapon == null || removableDecorator == null)");
                return;
            }

            IWeapon weapon = AssembleWeapon();
            inputHandler = GetInputHandler();
            pool = new GameObjectPool(bulletImpactEffect);
            SetupStates(weapon);
        }

        private void Update()
        {
            inputHandler.Update();
            fsm.Update();
        }

        /// <summary>
        /// Turns this into a class ?
        /// Feels more like a functioanl something.
        /// </summary>
        private IWeapon AssembleWeapon()
        {
            IWeapon weapon = baseWeapon;

            for (int i = 0; i < weaponDecorators.Count; i++)
            {
                weapon = weaponDecorators[i].Decorate(weapon);
            }

            return weapon;
        }

        private InputHandler GetInputHandler()
        {
            var inputHandler = new InputHandler();
            bindings.ForEach(x => inputHandler.AddBinding(x));

            return inputHandler;
        }

        private void SetupStates(IWeapon weapon)
        {
            var reloading = new ReloadingWeaponState();
            var toggle = new ToggleDecoratorWeaponState();
            var ready = new ReadyWeaponState();

            fsm.AddState(WeaponState.READY_STATE_NAME, ready);
            fsm.AddState(WeaponState.RELOADING_STATE_NAME, reloading);
            fsm.AddState(WeaponState.TOGGLE_STATE_NAME, toggle);

            reloading.OnReload += ready.Reload;
            foreach (var state in fsm.GetStates())
            {
                state.SetupBase(inputHandler, weapon, source);
                toggle.OnNewWeapon += state.UpdateWeapon;
            }

            reloading.Setup();
            toggle.Setup(removableDecorator);
            ready.Setup(eyes, pool);

            fsm.TransitionTo(WeaponState.READY_STATE_NAME);
        }
    }
}