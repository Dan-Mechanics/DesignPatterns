using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace DesignPatterns
{
    public interface IFoo<T> 
    {
        event Action<T> Action;
        UnityEvent<T> UnityEvent { get; }
    }

    public interface IVertsPasser
    {
        event Action<Vector3[]> OnPassVerts;
    }
}