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
        [SerializeField] private List<InputHandler.Binding> bindings = default;
        [SerializeField] private BaseWeapon baseWeapon = default;
        [SerializeField] private List<WeaponDecorator> weaponDecorators = default;
        [SerializeField] private Transform eyes = default;

        private InputHandler inputHandler;
        private readonly FSM<WeaponState> fsm = new FSM<WeaponState>();

        private void Start()
        {
            IWeapon weapon = AssembleWeapon();
            // decorate here.

            inputHandler = new InputHandler(bindings);

            ReloadingWeaponState reloading = new ReloadingWeaponState(fsm, inputHandler, weapon);
            ReadyWeaponState ready = new ReadyWeaponState(fsm, inputHandler, weapon, reloading, eyes);

            fsm.AddState(reloading);
            fsm.AddState(ready);

            fsm.TransitionTo(ready);
        }

        private void Update()
        {
            inputHandler.Update();
            fsm.Update();
        }

        private void Log()
        {
            print("bro is de logger!!");
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
    }
}