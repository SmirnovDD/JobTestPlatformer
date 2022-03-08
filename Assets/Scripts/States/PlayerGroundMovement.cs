using JobTest.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JobTest.States
{
    public class PlayerGroundMovement : PlayerState
    {
        private readonly InputAction _inputActionMove;
        private readonly InputAction _inputActionJump;

        public PlayerGroundMovement(PlayerStateData playerStateData) : base(playerStateData)
        {
            _inputActionMove = _inputControls.Gameplay.MoveHorizontally;
            _inputActionJump = _inputControls.Gameplay.Jump;
        }
        
        public override void Update()
        {
            MoveHorizontally();
            Jump();
            CheckGroundCollision();
        }

        private void Jump()
        {
            if (_inputActionJump.triggered)
            {
                var yVelocity = PlayerParameters.JUMP_HEIGHT * Mathf.Sqrt(-Physics.gravity.y);
                var groundedState = new PlayerJump(_playerController.PlayerStateData, yVelocity);
                _playerController.ChangeMovementState(groundedState);
            }
        }

        private void CheckGroundCollision()
        {
            if (_characterController.isGrounded)
                return;
            
            var inAirState = new PlayerJump(_playerController.PlayerStateData, Physics.gravity.y / 2);
            _playerController.ChangeMovementState(inAirState);
        }

        private void MoveHorizontally()
        {
            var movementDirection = _inputActionMove.ReadValue<Vector2>();
            var movementVector = movementDirection * PlayerParameters.SPEED * _gameTime.DeltaTime;
            _characterController.Move(new Vector3(movementVector.x, -0.1f, 0)); //small negative Y value to ensure ground collision
        }
    }
}