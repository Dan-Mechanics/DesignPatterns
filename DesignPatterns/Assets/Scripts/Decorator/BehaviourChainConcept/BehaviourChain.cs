using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourChainConcept
{
    public abstract class BehaviourChain
    {
        private BehaviourChain next;

        public BehaviourChain() { }

        public virtual void DoSomething() 
        {
            if(next != null)
                next.DoSomething();
        }

        public void SetNext(BehaviourChain next)
        {
            this.next = next;
        }

        /// <summary>
        /// This will prolly cause a crash !!.
        /// </summary>
        /// <param name="next"></param>
        public void Add(BehaviourChain next) 
        {
            BehaviourChain curr = this;

            while (curr.next != null) 
            {
                curr = curr.next;
            }

            curr.next = next;
        }

        /// <summary>
        /// I could prolly make this more efficient but ehhh.
        /// </summary>
        private void RemoveOne()
        {
            if (next == null)
            {
                Debug.LogWarning("Cannot remove when we have no next...");
                return;
            }

            BehaviourChain prev = null;
            BehaviourChain curr = this;

            while (curr.next != null)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = null;
        }

        public void Remove(int count = 1) 
        {
            if (count < 1)
                return;

            for (int i = 0; i < count; i++)
            {
                RemoveOne();
            }
        }
    }
}