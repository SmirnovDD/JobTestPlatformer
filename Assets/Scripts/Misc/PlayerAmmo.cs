using JobTest.Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace JobTest.Ammo
{
    public class PlayerAmmo : MonoBehaviour
    {
        private ObjectPool<GameObject> _pool;

        public void SetPool(ObjectPool<GameObject> pool)
        {
            _pool = pool;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            CheckEnemyHit(other);
            OnHit();
        }

        private void CheckEnemyHit(Collider other)
        {
            var enemy = other.GetComponent<IEnemy>();
            if (enemy != null)
                enemy.Kill();
        }
        private void OnHit()
        {
            _pool.Release(gameObject);
        }
    }
}