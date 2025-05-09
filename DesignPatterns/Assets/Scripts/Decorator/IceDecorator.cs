using UnityEngine;

public class IceDecorator : DamageSpellDecorator
{
    public IceDecorator(int damage) : base(damage) { }

    public override ISpell Decorate(ISpell spell)
    {
        Debug.Log("Add ice to it!");

        spell.SpellTypes |= SpellType.Ice;
        spell.Damage += Damage;

        return spell;
    }
}
