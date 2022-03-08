using JobTest.CameraControl;
using JobTest.Player;
using JobTest.Time;
using UnityEngine;

namespace JobTest.States
{
    public class PlayerStateData
    {
        public PlayerController PlayerController { get; }
        public CharacterController CharacterController { get; }
        public InputControls InputControls { get; }
        public IGameTime GameTime { get; }
        public ICameraController CameraController;
        
        public PlayerStateData(PlayerController playerController, CharacterController characterController, InputControls inputControls, IGameTime gameTime, ICameraController cameraController)
        {
            PlayerController = playerController;
            CharacterController = characterController;
            InputControls = inputControls;
            GameTime = gameTime;
            CameraController = cameraController;
        }
    }
}