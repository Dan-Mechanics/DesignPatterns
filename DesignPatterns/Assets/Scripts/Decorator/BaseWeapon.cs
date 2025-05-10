using UnityEngine;
using System;

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

        public string GetName() => name;
        public float GetReloadTime() => reloadTime;
        public int GetMaxBullets() => maxBullets;
        public float GetDamage() => damage;
        public float GetShootInterval() => shootInterval;
    }
}