using JobTest.Player;
using UniRx;
using UnityEngine;

namespace JobTest.Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public ReactiveProperty<bool> Dead { get; } = new (false);

        public void Kill()
        {
            Dead.Value = true;
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            CheckForPlayer(other);
        }

        private void CheckForPlayer(Collision other)
        {
            var player = other.gameObject.GetComponent<IPlayer>();
            if (player != null)
                player.Kill();
        }
    }
}