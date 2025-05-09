using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourChainConcept
{
    public class BehaviourChainBuilder
    {
        private readonly List<BehaviourChain> chain = new List<BehaviourChain>();

        public BehaviourChainBuilder() { }

        public BehaviourChainBuilder Add(BehaviourChain after) 
        {
            chain.Add(after);
            return this;
        }

        public BehaviourChain Build() 
        {
            if (chain.Count <= 0)
                return null;

            if (chain.Count < 2)
            {
                // for clarity.
                chain[0].SetNext(null);
                return chain[0];
            }

            for (int i = 0; i < chain.Count; i++)
            {
                if (i + 1 < chain.Count)
                {
                    chain[i].SetNext(chain[i + 1]);
                }
            }

            return chain[0];
        }

        public void Clear() 
        {
            chain.Clear();
        }
    }
}