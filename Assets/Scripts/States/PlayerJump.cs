using JobTest.Player;
using UnityEngine;

namespace JobTest.States
{
    public class PlayerJump : PlayerInAirState
    {
        public PlayerJump(PlayerStateData playerStateData, float yVelocity) : base(playerStateData, yVelocity)
        {
        }

        public override void Update()
        {
            base.Update();
            DoubleJump();
        }

        private void DoubleJump()
        {
            if (_inputActionJump.triggered)
            {
                var yVelocity = PlayerParameters.JUMP_HEIGHT * Mathf.Sqrt(-Physics.gravity.y);
                var groundedState = new PlayerInAirState(_playerController.PlayerStateData, yVelocity);
                _playerController.ChangeMovementState(groundedState);
            }
        }
    }
}