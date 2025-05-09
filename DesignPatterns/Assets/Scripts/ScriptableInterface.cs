using System;
using UnityEngine;

namespace DesignPatterns
{
    [Serializable]
    public class ScriptableInterface<T>
    {
        public ScriptableObject scriptable;
        public T attached;

        public void Setup()
        {
            if (scriptable == null)
            {
                Debug.LogError($"please assign scriptable");
                return;
            }


            //IWeapon dw = (IWeapon)scriptable;

            //IWeapon weapon = (T.GetType())scriptable;

            if (attached == null)
                Debug.LogError($"if (attached == null), on {GetType()}");
        }
    }
}