using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    public interface IState
    {
        /// <summary>
        /// Is this correct? with the setup ? idk. maybe we needto make Istate of T
        /// </summary>
        /// <param name="fsm"></param>
        void Setup(FSM<IState> fsm);
        void EnterState();
        void Update();
        void ExitState();
    }
}