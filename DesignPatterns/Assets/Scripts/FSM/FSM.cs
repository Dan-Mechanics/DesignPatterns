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

    public interface IState
    {
        void Setup(FSM<IState> fsm);
        void EnterState();
        void Update();
        void ExitState();
    }

    public abstract class WeaponState : IState
    {
        public virtual void DoPrimaryFire(IWeapon weapon)
        {

        }

        public void EnterState()
        {
            throw new NotImplementedException();
        }

        public void ExitState()
        {
            throw new NotImplementedException();
        }

        public void Setup(FSM<IState> fsm)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}