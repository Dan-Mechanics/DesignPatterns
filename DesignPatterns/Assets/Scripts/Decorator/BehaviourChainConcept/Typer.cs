using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourChainConcept
{
    public class Typer : BehaviourChain
    {
        private readonly string text;

        public Typer(string text) : base()
        {
            this.text = text;
        }

        /*public Typer(Yapper after, string text) : base(after)
        {
            this.text = text;
        }*/

        public override void DoSomething()
        {
            Debug.Log(text);
            base.DoSomething();
        }
    }
}