using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    /// <summary>
    /// Question for Aaron: does this break the interface segregation principle?
    /// I think im overthinking it in this context but in the future i could split this enum into 
    /// different types of shit.
    /// </summary>
    public interface ITerrainable 
    {
        /// <summary>
        /// This will mean we have to do some memes
        /// </summary>
        float GetHeightAtPoint(float x, float y, float z);

        int GetSize();
        float GetWaterHeight();
        //Biome GetBiome();
    }
}