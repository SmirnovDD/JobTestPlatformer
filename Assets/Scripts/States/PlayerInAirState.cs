using JobTest.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JobTest.States
{
    public class PlayerInAirState : PlayerState
    {
        protected readonly InputAction _inputActionJump;
        private readonly InputAction _inputActionMove;
        private float _xVelocity;
        private float _yVelocity;

        public PlayerInAirState(PlayerStateData playerStateData, float yVelocity) : base(playerStateData)
        {
            _inputActionJump = _inputControls.Gameplay.Jump;
            _inputActionMove = _inputControls.Gameplay.MoveHorizontally;
            _yVelocity = yVelocity;
        }

        public override void Update()
        {
            ApplyHorizontalVelocity();
            ApplyGravity();
            Move();
            CheckGroundCollision();
        }
        
        private void ApplyGravity()
        {
            _yVelocity += Physics.gravity.y * _gameTime.DeltaTime;
        }
        
        private void ApplyHorizontalVelocity()
        {
            var movementDirection = _inputActionMove.ReadValue<Vector2>();
            _xVelocity = movementDirection.x * PlayerParameters.SPEED * _gameTime.DeltaTime;
        }

        private void Move()
        {
            _characterController.Move(new Vector3(_xVelocity, _yVelocity * _gameTime.DeltaTime, 0));
        }
        
        private void CheckGroundCollision()
        {
            if (!_characterController.isGrounded)
                return;

            var groundedState = new PlayerGroundMovement(_playerController.PlayerStateData);
            _playerController.ChangeMovementState(groundedState);
        }
    }
}