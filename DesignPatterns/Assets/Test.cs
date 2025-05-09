using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace DesignPatterns
{
    public class Test : MonoBehaviour, IFoo<float>
    {
        //[SerializeField] private ScriptableInterface<IWeapon> baseWeapon = default;

        [SerializeField] private InspectorInterface<IVertsPasser> memes = default;

        //public UnityEvent<float> UnityEvent => unityEvent;

        //UnityEvent<float> IFoo<float>.UnityEvent => someevent;

        [SerializeField] private UnityEvent<float> someevent;

        public UnityEvent<float> UnityEvent => someevent;

        public event Action<float> Action;

        private void Awake()
        {
           // baseWeapon.Setup();

            memes.Setup();

            memes.attached.OnPassVerts += Attached_OnPassVerts;
            //memes.attached.Action += MEMES;

            Action?.Invoke(0f);

            Action += yeet;
        }

        private void yeet(float obj)
        {
            someevent?.Invoke(obj);
        }

        private void Attached_OnPassVerts(Vector3[] obj)
        {
            throw new NotImplementedException();
        }

        private void MEMES(float obj)
        {
            throw new System.NotImplementedException();
        }
    }
}