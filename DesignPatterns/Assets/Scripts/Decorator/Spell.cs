using UnityEngine;

public class Spell : ISpell
{
    public int Damage { get; set; }
    public SpellType SpellTypes { get; set; } = SpellType.Normal;

    public Spell(int damage)
    {
        Damage = damage;
    }

    public void Cast()
    {
        Debug.Log("Do the damage: " + Damage + " " + SpellTypes);
    }

}
