using UnityEngine;

namespace DesignPatterns
{
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(ExtendedMagDecorator), fileName = "New " + nameof(ExtendedMagDecorator))]
    public class ExtendedMagDecorator : WeaponDecorator
    {
        [Header(nameof(ExtendedMagDecorator))]
        [Min(1)] public int bulletGained;

        public override int GetMaxBullets()
        {
            return base.GetMaxBullets() + bulletGained;
        }
    }
}