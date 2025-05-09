public abstract class DamageSpellDecorator
{
    public int Damage {  get; set; }
    public DamageSpellDecorator(int damage)
    {
        Damage = damage;
    }

    public abstract ISpell Decorate(ISpell spell);
}
