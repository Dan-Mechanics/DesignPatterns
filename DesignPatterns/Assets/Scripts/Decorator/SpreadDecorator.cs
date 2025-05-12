using UnityEngine;

namespace DesignPatterns
{
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(SpreadDecorator), fileName = "New " + nameof(SpreadDecorator))]
    public class SpreadDecorator : WeaponDecorator
    {
        [Header(nameof(SpreadDecorator))]
        [Min(0f)] public float spread;

        public override float GetSpread()
        {
            return base.GetSpread() + spread;
        }
    }
}