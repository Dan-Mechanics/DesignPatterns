public interface ISpell 
{
    int Damage { get; set; }
    SpellType SpellTypes { get; set; }
    void Cast();
}