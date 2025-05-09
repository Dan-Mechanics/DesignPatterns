using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cool !
/// </summary>
public class InputHandler
{
    private readonly List<Binding> bindings = new List<Binding>();

    public void Update()
    {
        foreach (var binding in bindings)
        {
            if (Input.GetKeyDown(binding.key))
                binding.command.Execute();
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
