using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Now expand this to include scriptable objects too.
    /// </summary>
    [Serializable]
    public class InspectorInterface<T>
    {
        /// <summary>
        /// Could i add other things like ScriptableOjbect i nthe futuer?
        /// </summary>
        public MonoBehaviour monoBehaviour;
        public T attached;

        public void Setup()
        {
            if (monoBehaviour == null)
            {
                Debug.LogError($"please assign monoBehaviour");
                return;
            }

            attached = monoBehaviour.GetComponent<T>();

            if (attached == null)
                Debug.LogError($"if (attached == null), on {GetType()}");
        }
    }
}