using UnityEngine;

namespace DesignPatterns
{
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(BaseWeapon), fileName = "New " + nameof(BaseWeapon))]
    public class BaseWeapon : ScriptableObject, IWeapon
    {
        [Header(nameof(BaseWeapon))]
        [Min(0f)] public float reloadTime;
        [Min(1)] public int maxBullets;
        [Min(0f)] public float damage;
        [Min(0f)] public float shootInterval;
        [Min(0f)] public float maxBulletRange;
        public AudioClip shootSound;
        public AudioClip reloadSound;

        public float GetDamage() => damage;
        public float GetMaxBulletRange() => maxBulletRange;
        public int GetMaxBullets() => maxBullets;
        public float GetSpread() => 0f;
        public string GetName() => name;
        public AudioClip GetReloadSound() => reloadSound;
        public float GetReloadTime() => reloadTime;
        public float GetShootInterval() => shootInterval;
        public AudioClip GetShootSound() => shootSound;
    }
}