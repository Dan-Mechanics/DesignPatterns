using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    public class Effect : MonoBehaviour, IPoolable
    {
        public bool Active { get; set; }
        public event Action<Effect> OnDone;

        public void Disable()
        {
            gameObject.SetActive(false);
            OnDone = null;
        }

        public void Dump()
        {
            Destroy(gameObject);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void OnDisable()
        {
            OnDone?.Invoke(this);
        }
    }
}