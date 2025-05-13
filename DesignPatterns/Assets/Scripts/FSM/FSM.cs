using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns
{
    public class FSM<T> where T : IState
    {
        private readonly Dictionary<Type, T> states = new Dictionary<Type, T>();
        private T current;

        public void Update() => current?.Update();

        public void AddState(T state)
        {
            Debug.Log($"added {state.GetType()}");
            states.Add(state.GetType(), state);
        }

        /// <summary>
        /// Technically speaking you shouldn't be allowed
        /// to remove states ...
        /// </summary>
        public void RemoveState(Type type)
        {
            Debug.Log($"removed {type}");

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

            Debug.Log($"state is now <b>{current.GetType()}</b>");
        }

        public void TransitionTo(T state)
        {
            if (state == null)
                return;
            
            TransitionTo(state.GetType());
        }

        public List<T> GetStates() => states.Values.ToList();
    }
}