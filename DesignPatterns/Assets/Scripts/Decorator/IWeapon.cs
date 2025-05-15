using UnityEngine;

namespace DesignPatterns
{
    public interface IWeapon 
    {
        string GetName();
        float GetReloadTime();
        int GetMaxBullets();
        float GetDamage();
        float GetShootInterval();
        float GetMaxBulletRange();
        float GetSpread();
        AudioClip GetShootSound();
        AudioClip GetReloadSound();

        // Or what have you ...
    }
}