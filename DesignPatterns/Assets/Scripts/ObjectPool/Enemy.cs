using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class Enemy : IPoolable
    {
        public bool Active { get; set; }
        public event Action<Enemy> OnDie;

        public void Die() 
        {
            OnDie?.Invoke(this);
        }

        public void Disable()
        {
            Debug.Log("Enemy deactivated !");
            OnDie = null;
        }

        public void Enable()
        {
            Debug.Log("Enemy activated !");
        }

        public void Dump() { Disable(); }
    }
}