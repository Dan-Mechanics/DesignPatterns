namespace DesignPatterns
{
    /// <summary>
    /// We coullllddd add Shoot() method here but for now we're just looking at changing numbers.
    /// Note: this system does not yet implement spread and shotguns but i could easily add that.
    /// </summary>
    public interface IWeapon 
    {
        string GetName();
        float GetReloadTime();
        int GetMaxBullets();
        float GetDamage();
        float GetShootInterval();
        float GetMaxBulletRange();
        // Or what have you ...
    }
}