using JobTest.CameraControl;
using JobTest.Player;
using JobTest.Time;
using UnityEngine;

namespace JobTest.States
{
    public abstract class PlayerState : IPlayerState
    {
        protected PlayerController _playerController;
        protected CharacterController _characterController;
        protected InputControls _inputControls;
        protected IGameTime _gameTime;
        protected ICameraController _cameraController;
        
        protected PlayerState(PlayerStateData playerStateData)
        {
            _playerController = playerStateData.PlayerController;
            _characterController = playerStateData.CharacterController;
            _inputControls = playerStateData.InputControls;
            _gameTime = playerStateData.GameTime;
            _cameraController = playerStateData.CameraController;
        }
        
        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}