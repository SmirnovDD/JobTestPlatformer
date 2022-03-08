using JobTest.Ammo;
using JobTest.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JobTest.States
{
    public class PlayerShootState : PlayerState
    {
        private InputAction _inputActionAim;
        private InputAction _inputActionShoot;
        private Vector2 _shootVector;
        private AmmoPool _ammoPool;
        private float _timer = PlayerParameters.SHOOT_DELAY;
        private AimType _aimType;
        private Transform _transform;
        
        private enum AimType
        {
            AtMousePosition,
            AtStickPosition
        }
        
        public PlayerShootState(PlayerStateData playerStateData) : base(playerStateData)
        {
            _inputActionAim = _inputControls.Gameplay.Aim;
            _inputActionShoot = _inputControls.Gameplay.Shoot;
            _ammoPool = new AmmoPool();
            InputSystem.onActionChange += CheckDevice;
            _transform = _characterController.transform;
        }

        public override void Update()
        {
            Aim();
            Shoot();
        }

        private void CheckDevice(object obj, InputActionChange actionChange) //TODO this is a crutch, I`m really pressed by time right now, It needs to be changed in the future
        {
            if (obj is not InputAction inputAction)
                return;
            
            var lastControl = inputAction.activeControl;

            if (lastControl == null)
                return;
            
            var lastDevice = lastControl.device;
            if (lastDevice == Mouse.current)
                _aimType = AimType.AtMousePosition;
            else if (lastDevice == Gamepad.current)
                _aimType = AimType.AtStickPosition; 
        }
        
        private void Aim()
        {
            var inputVector = _inputActionAim.ReadValue<Vector2>();
            if (_aimType == AimType.AtMousePosition)
            {
                var mouseScreenPosVector = new Vector3(inputVector.x, inputVector.y, -_cameraController.CameraTransform.position.z);
                var mouseWorldPoint = _cameraController.Camera.ScreenToWorldPoint(mouseScreenPosVector);
                _shootVector = (mouseWorldPoint - _transform.position).normalized;
            }
            if (_aimType == AimType.AtStickPosition)
                _shootVector = inputVector;
        }

        private void Shoot()
        {
            if (_inputActionShoot.inProgress && _timer >= PlayerParameters.SHOOT_DELAY)
            {
                var ammo = _ammoPool.GetAmmo();
                var ammoRigidBody = ammo.GetComponent<Rigidbody>();
                ammo.transform.position = _characterController.transform.position + Vector3.up * 0.5f;
                ammoRigidBody.velocity = Vector3.zero;
                ammoRigidBody.AddForce(_shootVector * PlayerParameters.SHOOT_FORCE); 
                _timer = 0; //TODO running out of time, so dirty code here
            }

            _timer += _gameTime.DeltaTime;
        }

        public override void Exit()
        {
            InputSystem.onActionChange -= CheckDevice;
        }
    }
}