using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Note to sefl: we do need to give a reference to inputhandler to the states.
    /// so they can implemetn that in their own shit, or we say 
    /// </summary>
    public class PlayerContext : MonoBehaviour
    {
        private InputHandler inputHandler;

        private readonly FSM<WeaponState> fsm = new FSM<WeaponState>();

        [SerializeField] private List<InputHandler.Binding> bindings = default;

        [SerializeField] private BaseWeapon baseWeapon = default;

        private void Start()
        {
            IWeapon weapon = baseWeapon;
            
            
            inputHandler = new InputHandler(bindings);

            ReloadingWeaponState reloading = new ReloadingWeaponState(fsm, inputHandler, weapon);
            ReadyWeaponState ready = new ReadyWeaponState(fsm, inputHandler, weapon, reloading);

            fsm.AddState(new ReadyWeaponState(fsm, inputHandler, weapon))
            
        }

        private void Update()
        {
            inputHandler.Update();
        }
    }
}