using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourChainConcept
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private AudioSource source = default;
        [SerializeField] private AudioClip clip = default;

        private BehaviourChain chain;

        private void Start()
        {
            BehaviourChainBuilder builder = new BehaviourChainBuilder();

            builder
                .Add(new Typer("RAAAAHHHH"))
                .Add(new Screamer(source, clip))
                .Add(new Typer("wow there"))
                .Add(new Typer("that was loud"));

            chain = builder.Build();

            //chain.Add(new Typer("new stuff here"));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chain.DoSomething();
                chain.Remove();
            }
        }
    }
}