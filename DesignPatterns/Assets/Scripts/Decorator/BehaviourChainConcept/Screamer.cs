using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourChainConcept
{
    public class Screamer : BehaviourChain
    {
        private readonly AudioSource source;
        private readonly AudioClip clip;

        public Screamer(AudioSource source, AudioClip clip) : base()
        {
            this.source = source;
            this.clip = clip;
        }

        /*public Screamer(Yapper after, AudioSource source, AudioClip clip) : base(after)
        {
            this.source = source;
            this.clip = clip;
        }*/

        public override void DoSomething()
        {
            //Debug.Log("Debug: " + clip.name);
            source.PlayOneShot(clip);

            base.DoSomething();
        }
    }
}