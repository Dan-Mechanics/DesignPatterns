using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    /// <summary>
    /// THERE IS LITERALLY NO WAY THIS WORKS NOOOO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IState
    {
        /// <summary>
        /// Is this correct? with the setup ? idk. maybe we needto make Istate of T
        /// Look if you could make this work.
        /// </summary>
        /// <param name="fsm"></param>
        //void Setup(FSM<T> fsm);
        void EnterState();
        void Update();
        void ExitState();
    }
}