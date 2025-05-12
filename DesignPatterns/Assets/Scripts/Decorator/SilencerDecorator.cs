using UnityEngine;

namespace DesignPatterns
{
    /// <summary>
    /// I could make it so that it changes the spread and damage but the sound 
    /// is fine for now.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObject/" + nameof(SilencerDecorator), fileName = "New " + nameof(SilencerDecorator))]
    public class SilencerDecorator : WeaponDecorator
    {
        [Header(nameof(SilencerDecorator))]
        public AudioClip silencedShootSound;

        public override AudioClip GetShootSound()
        {
            return silencedShootSound;
        }
    }
}