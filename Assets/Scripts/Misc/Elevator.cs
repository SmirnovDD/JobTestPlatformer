using System;
using DG.Tweening;
using DG.Tweening.Core;
using JobTest.Player;
using JobTest.Time;
using UnityEngine;
using Zenject;

namespace JobTest.Misc
{
    public class Elevator : MonoBehaviour //TODO quite dirty, but gets the job done for now
    {
        [SerializeField] private float _raiseBy;
        [SerializeField] private float _delay = 2f;
        [SerializeField] private Collider _collider;
        private Rigidbody _rb;
        private IPlayer player;
        private IGameTime _gameTime;

        [Inject]
        public void Init(IGameTime gameTime)
        {
            _gameTime = gameTime;
        }

        private void Update()
        {
            DOTween.ManualUpdate(_gameTime.DeltaTime, UnityEngine.Time.unscaledDeltaTime);//should normally be elsewhere of course
        }

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rb = GetComponent<Rigidbody>();
            Sequence s = DOTween.Sequence();
            s.SetDelay(_delay/2);
            s.Append(_rb.DOMoveY(_raiseBy, 5f).SetRelative().SetEase(Ease.Linear));
            s.AppendInterval(_delay/2);
            s.SetLoops(-1, LoopType.Yoyo);
            s.SetUpdate(UpdateType.Manual);
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            player = other.gameObject.GetComponent<IPlayer>();
            if (player != null)
            {
                if (CheckForSmash(player.Transform.position) && player.PlayerController.CharacterController.isGrounded)
                    player.Kill();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (player != null && player.PlayerController != null)
                player.PlayerController.CharacterController.Move(_rb.velocity * UnityEngine.Time.deltaTime);
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IPlayer>() == player)
                player = null;
        }

        private bool CheckForSmash(Vector3 targetPosition)
        {
            var bounds = _collider.bounds;
            if (targetPosition.x < bounds.max.x && 
                targetPosition.x > bounds.min.x &&
                targetPosition.y < bounds.max.y)
                return true;
            return false;
        }
    }
}