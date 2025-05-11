using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class InputHandler
    {
        //public Dictionary<PlayerAction, InputPair> Conversions => conversions;

        /// <summary>
        /// Ideally we load this is via config file.
        /// </summary>
        private readonly List<Binding> bindings;
        private readonly Dictionary<PlayerAction, InputEvents> conversion;

        /// <summary>
        /// Bindings is from editor.
        /// But theorietically it could be from config txt file.
        /// </summary>
        /// <param name="bindings"></param>
        public InputHandler(List<Binding> bindings = null)
        {
            this.bindings = bindings ?? new List<Binding>();
            conversion = new Dictionary<PlayerAction, InputEvents>();

            // Or we could generate them as they are needed, but this is a little smoother.
            for (int i = 0; i < Enum.GetValues(typeof(PlayerAction)).Length; i++)
            {
                conversion.Add((PlayerAction)i, new InputEvents());
            }
        }

        public void AddBinding(Binding binding) 
        {
            // This is where you can define the rules for which bindings are allowed.

            // Right now: A --> PrimaryFire AND A --> SecondaryFire
            // but not A AND B --> PrimaryFire.

            // Or we can have it that only one key is allowed to do one thing
            // but then multible keys can point to the same action still.

            // Or we have it that one key does one thing and an action can only have
            // one thing associated with it, but what's the fun in that ?

            for (int i = 0; i < bindings.Count; i++)
            {
                if (binding.playerAction == bindings[i].playerAction)
                    return;
            }
            
            bindings.Add(binding);
        }

        public void RemoveBinding(Binding binding) => bindings.Remove(binding);

        public void RemoveByKey(KeyCode key) 
        {
            for (int i = bindings.Count - 1; i >= 0; i--)
            {
                if (bindings[i].key == key)
                    bindings.RemoveAt(i);
            }
        }

        public void RemoveByPlayerAction(PlayerAction playerAction) 
        {
            for (int i = bindings.Count - 1; i >= 0; i--)
            {
                if (bindings[i].playerAction == playerAction)
                    bindings.RemoveAt(i);
            }
        }

        public void Update()
        {
            foreach (var binding in bindings)
            {
                if (!conversion.ContainsKey(binding.playerAction))
                    continue;

                if (Input.GetKeyDown(binding.key))
                {
                    conversion[binding.playerAction].OnDown?.Invoke();
                    conversion[binding.playerAction].OnChange?.Invoke(true);
                }

                if (Input.GetKeyUp(binding.key)) 
                {
                    conversion[binding.playerAction].OnUp?.Invoke();
                    conversion[binding.playerAction].OnChange?.Invoke(false);
                }
            }
        }

        public InputEvents GetInputEvents(PlayerAction playerAction) => conversion[playerAction];

        /*public InputEvents GetInputEvents(PlayerAction playerAction)
        {
            // This if statement COULD be removed !!
            if (!conversion.ContainsKey(playerAction))
                return null;

            return conversion[playerAction];
        }*/

        [Serializable]
        public class Binding
        {
            public KeyCode key;
            public PlayerAction playerAction;

            public Binding(KeyCode key, PlayerAction playerAction)
            {
                this.key = key;
                this.playerAction = playerAction;
            }
        }

        /// <summary>
        /// Can this be a struct?
        /// </summary>
        [System.Serializable]
        public class InputEvents 
        {
            public Action OnDown;
            public Action OnUp;
            public Action<bool> OnChange;
        }
    }

}