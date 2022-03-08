using UniRx;
using UnityEngine;

namespace JobTest.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        private Transform _transform;
        public Transform Transform => _transform;
        private PlayerController _playerController;
        public PlayerController PlayerController => _playerController;
        public ReactiveProperty<bool> Dead { get; } = new (false);

        private void Awake()
        {
            _transform = transform;
            _playerController = GetComponent<PlayerController>();
        }

        public void Kill()
        {
            Dead.Value = true;
            Destroy(gameObject);
        }
    }
}