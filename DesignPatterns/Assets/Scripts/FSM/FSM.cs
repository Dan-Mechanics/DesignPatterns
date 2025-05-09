using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns 
{
    public class FSM<T> where T : IState
    {
        public readonly Dictionary<Type, IState> states = new Dictionary<Type, IState>();

        public void AddState(System.Object state)
        {
        }

        public void TransitionTo(Type type)
        {
        }
    }
}