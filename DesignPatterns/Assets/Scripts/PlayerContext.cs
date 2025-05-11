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

        private void Start()
        {
            inputHandler = new InputHandler(bindings);

            //fsm.AddState(new Wea)
            inputHandler.Conversions.Clear();

            print(inputHandler.Conversions.Count);

            //fsm.states[0].Setup
            // example code.
            //inputHandler.AddBinding(new InputHandler.Binding(KeyCode.Mouse0, PlayerAction.PrimaryFire));
        }

        private void Update()
        {
            inputHandler.Update();
        }
    }
}