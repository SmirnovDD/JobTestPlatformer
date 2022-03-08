using JobTest.Time;
using UnityEngine;
using Zenject;

namespace JobTest.Misc
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        private IGameTime _gameTime;
        private Rigidbody _rigidbody;
        private Vector3 _storedVelocity;
        
        [Inject]
        public void Init(IGameTime gameTime)
        {
            _gameTime = gameTime;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _gameTime.OnPauseToggle += Freeze;
        }

        private void OnDisable()
        {
            _gameTime.OnPauseToggle -= Freeze;
        }

        private void Freeze(bool v) //TODO make a separate component for "pausing" rigidbodies and add it to bullets as well
        {
            if (v)
            {
                _storedVelocity = _rigidbody.velocity;
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.useGravity = false;
            }
            else
            {
                _rigidbody.isKinematic = false;
                _rigidbody.useGravity = true;
                _rigidbody.velocity = _storedVelocity;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(Vector3.left * _speed * _gameTime.DeltaTime, ForceMode.Force);
        }
    }
}