using UnityEngine;
using Zenject;

namespace JobTest.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private DiContainer _container;
        private Object _enemyPrefab;

        public EnemyFactory(DiContainer container)
        {
            _container = container;
        }

        public void Load()
        {
            _enemyPrefab = Resources.Load("Enemy");
        }

        public IEnemy Spawn(Vector3 position)
        {
            var enemy = _container.InstantiatePrefabForComponent<IEnemy>(_enemyPrefab, position, Quaternion.identity, null);
            return enemy;
        }
    }
}