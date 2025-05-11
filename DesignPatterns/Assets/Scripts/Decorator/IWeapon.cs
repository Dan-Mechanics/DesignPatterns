using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// We coullllddd add Shoot() method here but for now we're just looking at changing numbers.
    /// Note: this system does not yet implement spread and shotguns but i could easily add that.
    /// 
    /// Add spread ish
    /// </summary>
    public interface IWeapon 
    {
        string GetName();
        float GetReloadTime();
        int GetMaxBullets();
        float GetDamage();
        float GetShootInterval();
        float GetMaxBulletRange();
        AudioClip GetShootSound();
        AudioClip GetReloadSound();

        // Or what have you ...
    }
}