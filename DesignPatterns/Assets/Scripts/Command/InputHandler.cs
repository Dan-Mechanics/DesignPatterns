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
    /// </summary>
    public class InputHandler
    {
        private readonly List<Binding> bindings = new List<Binding>();

        public void Update()
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
        }

        public class Binding
        {
            public KeyCode key;
            public IWeaponCommand command;

            public Binding(KeyCode key, IWeaponCommand command)
            {
                this.key = key;
                this.command = command;
            }
        }
    }

}