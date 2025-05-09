using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPatterns
{
    public class TerrainBuilder : MonoBehaviour
    {
        // inspector interface for scriptable objects here.
        
        public BaseWeapon baseTerrain;
        public WeaponDecorator[] decorators;
    }
}