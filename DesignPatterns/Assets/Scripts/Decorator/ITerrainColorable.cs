using UnityEngine;

namespace DesignPatterns
{
    public interface ITerrainableColorable 
    {
        Texture2D GetTexture();
        float GetColorFloor(float min);
        float GetColorCeiling(float max);
        //Color GetIntroductionColor();
    }
}