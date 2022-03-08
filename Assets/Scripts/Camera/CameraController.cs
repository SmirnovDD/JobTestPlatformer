using JobTest.Player;
using UnityEngine;
using Zenject;

namespace JobTest.CameraControl
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        [SerializeField] private Camera _camera;
        public Camera Camera => _camera;

        [SerializeField] private Vector3 _targetOffset = new (0, 0, 10);
        
        private Transform _cameraTransform;
        public Transform CameraTransform => _cameraTransform;

        private Transform _targetToFollowTransform;
        
        public void SetTargetToFollow(Transform targetToFollowTransform)
        {
            _targetToFollowTransform = targetToFollowTransform;
        }
        
        private void Awake()
        {
            _cameraTransform = _camera.transform;
        }

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_targetToFollowTransform != null)
                _cameraTransform.position = _targetToFollowTransform.position - _targetOffset;
        }
    }
}