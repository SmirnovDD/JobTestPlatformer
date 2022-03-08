using UnityEngine;

namespace JobTest.Enemy
{
    public interface IEnemyFactory
    {
        void Load();
        IEnemy Spawn(Vector3 position);
    }
}