using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns 
{
    public class FSM<T> where T : IState
    {
        private readonly Dictionary<Type, T> states = new Dictionary<Type, T>();
        private T current;

        public void Update() => current?.Update();

        public void AddState(T state)
        {
            //state.Setup(this);
            Debug.Log(state.GetType());
            states.Add(state.GetType(), state);
        }

        public void RemoveState(Type type)
        {
            if (current.GetType() == type)
                current = default;

            if (!states.ContainsKey(type))
                return;

            states.Remove(type);
        }

        public void TransitionTo(Type type)
        {
            if (!states.ContainsKey(type))
                return;

            current?.ExitState();
            current = states[type];
            current.EnterState();
        }
    }
}