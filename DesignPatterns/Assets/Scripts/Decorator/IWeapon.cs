namespace DesignPatterns
{
    public interface IWeapon 
    {
        string GetName();
        float GetReloadTime();
        int GetMaxBullets();
        float GetDamage();
        float GetShootInterval();

        // Or what have you ...
    }
}