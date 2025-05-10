using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// Cool !
    /// 
    /// 
    /// WEll clearly this isnt gonna work anymore given that
    /// emmes, but we can still return a thing and we can also bind multible commands
    /// to one key and mutlible keys to one comamnd but eyah/
    /// 
    /// Naming could be better here.
    /// </summary>
    public class InputHandlerObserver : MonoBehaviour
    {
        public enum AssociatedAction 
        { 
            None = 0,
            PrimaryFire = 1,
            SecondaryFire = 2,
            Reload = 3
        }

        //public Dictionary<AssociatedAction, Moment> Conversions => conversions;

        public event Action OnPrimaryFireDown;
        public event Action OnPrimaryFireUp;

        /// <summary>
        /// This SHOULD be loaded in via config file ideally.
        /// </summary>
        [SerializeField] private List<Binding> bindings = new List<Binding>();
        private readonly Dictionary<AssociatedAction, UpDownPair> conversions = new Dictionary<AssociatedAction, UpDownPair>();

        private void Start()
        {
            // or we make it when a player needs it.
            for (int i = 0; i < Enum.GetValues(typeof(AssociatedAction)).Length; i++)
            {
                conversions.Add((AssociatedAction)i, new UpDownPair());
            }
            
            //conversions.Add(AssociatedAction.PrimaryFire, new Moment());
        }

        private void Update()
        {
            /*for (int i = 0; i < bindings.Length; i++)
            {
                conversions.ContainsKey(bindings[i].assocatedAction){ }
            }*/

            foreach (var binding in bindings)
            {
                if (!conversions.ContainsKey(binding.assocatedAction))
                    continue;

                if (Input.GetKeyDown(binding.key))
                {
                    conversions[binding.assocatedAction].OnDown?.Invoke();
                }

                if (Input.GetKeyUp(binding.key)) 
                {
                    conversions[binding.assocatedAction].OnUp?.Invoke();
                }
            }
        }

        /// <summary>
        /// Or you could write a property.
        /// </summary>
        /// <param name="associated"></param>
        /// <returns></returns>
        public UpDownPair GetMoment(AssociatedAction associated) 
        {
            if (conversions.ContainsKey(associated))
                conversions.Add(associated, new UpDownPair());

            return conversions[associated];
        }

        //private readonly List<Binding> bindings = new List<Binding>();

        /*public void Update()
        {   
            foreach (var binding in bindings)
            {
                if (Input.GetKeyDown(binding.key))
                    binding.command.Execute(null, null);
            }
        }

        public void Bind(KeyCode key, IWeaponCommand command)
        {
            bindings.Add(new Binding(key, command));
        }

        public void Unbind(KeyCode key)
        {
            // Sure buddy.
            var items = bindings.FindAll(x => x.key == key);
            items.ForEach(x => bindings.Remove(x));
        }*/

        [System.Serializable]
        public class Binding
        {
            public KeyCode key;
            public AssociatedAction assocatedAction;

            /*public Binding(KeyCode key, IWeaponCommand command)
            {
                this.key = key;
                this.command = command;
            }*/
        }

        /// <summary>
        /// Can this be a struct?
        /// </summary>
        [System.Serializable]
        public class UpDownPair 
        {
            public Action OnDown;
            public Action OnUp;
        }
    }

}