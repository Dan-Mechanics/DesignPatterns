using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns
{
    public class FSM<T> where T : IState
    {
        private readonly Dictionary<string, T> states = new Dictionary<string, T>();
        private T current;

        public void Update() => current?.Update();

        public void AddState(string name, T state)
        {
            states.Add(name, state);
            state.OnTransitionRequest += TransitionTo;
            Debug.Log($"added {name}");
        }

        /// <summary>
        /// Remove this state and make current null or current is the 
        /// one we want to remove.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveState(string name)
        {
            if (!states.ContainsKey(name))
                return;
            
            if (current.Equals(states[name]))
                current = default;

            states.Remove(name);

            Debug.Log($"removed {name}");
        }

        public void TransitionTo(string name)
        {
            if (!states.ContainsKey(name))
                return;

            current?.ExitState();
            current = states[name];
            current.EnterState();

            Debug.Log($"state is now <b>{name}</b>");
        }

        public List<T> GetStates() => states.Values.ToList();
    }
}