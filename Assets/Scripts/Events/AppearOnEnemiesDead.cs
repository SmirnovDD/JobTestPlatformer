using System.Collections.Generic;
using JobTest.Enemy;
using UniRx;

namespace JobTest.Events
{
    public class AppearOnEnemiesDead : EventConditionAppear
    {
        private int _enemiesCount;
        
        public void Set(List<IEnemy> enemies)
        {
            _enemiesCount = enemies.Count;
            foreach (var enemy in enemies)
            {
                enemy.Dead.Subscribe(EnemyDied).AddTo(this);
            }
        }

        private void EnemyDied(bool dead)
        {
            if (dead)
                _enemiesCount--;
            if (_enemiesCount == 0)
                Appear();
        }
    }
}