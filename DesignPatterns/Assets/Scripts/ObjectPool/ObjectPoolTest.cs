using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ObjectPoolPattern
{
    public class ObjectPoolTest : MonoBehaviour
    {
        private readonly ObjectPool<Enemy> enemyPool = new ObjectPool<Enemy>();
        private readonly ObjectPool<Effect> effectPool = new ObjectPool<Effect>();

        [SerializeField] private GameObject bulletEffect = default;

        private void Start()
        {
            //ObjectPool<GameObject> gameOjbect = new ObjectPool<GameObject>();


        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Enemy enemy = enemyPool.RequestObject();
                enemy.OnDie += DeregisterEnemy;

                // code here ...

                enemy.Die();
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 raycastPos = Vector3.zero;

                Effect effect = effectPool.RequestGameObject(bulletEffect);

                effect.transform.position = raycastPos;
                effect.transform.forward = transform.forward;

                effect.OnDone += DeregisterEffect;
            }
        }

        public void DeregisterEnemy(Enemy enemy) 
        {
            enemyPool.ReturnObjectToPool(enemy);
        }

        public void DeregisterEffect(Effect effect) 
        {
            effectPool.ReturnObjectToPool(effect);
        }
    }
}