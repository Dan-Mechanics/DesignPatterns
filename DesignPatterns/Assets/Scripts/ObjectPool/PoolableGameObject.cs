using UnityEngine;

namespace DesignPatterns
{
    public class PoolableGameObject : MonoBehaviour
    {
        private GameObjectPool pool;

        public void Setup(GameObjectPool pool) => this.pool = pool;
        private void OnDisable() => pool.GiveToPool(gameObject);
    }
}