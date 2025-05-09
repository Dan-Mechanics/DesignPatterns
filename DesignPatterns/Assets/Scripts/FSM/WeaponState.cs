using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    /// <summary>
    /// Make sure to look at lsikov subsitution princple for this shit.
    /// </summary>
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