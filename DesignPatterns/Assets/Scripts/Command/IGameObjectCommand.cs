using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public interface IGameObjectCommand
    {
        void Execute(GameObject actor);
    }
}