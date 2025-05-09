using UnityEngine;

/// <summary>
/// This can be more generic ?? maybe its just for the example.
/// </summary>
public class FireDecorator : DamageSpellDecorator
{
    public FireDecorator(int damage) : base(damage) { }

    public override ISpell Decorate(ISpell spell)
    {
        Debug.Log("Add fire to it!");

        spell.SpellTypes |= SpellType.Fire;
        spell.Damage += Damage;

        return spell;
    }
}
