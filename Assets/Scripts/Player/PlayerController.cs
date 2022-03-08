using JobTest.CameraControl;
using JobTest.Input;
using JobTest.States;
using JobTest.Time;
using UnityEngine;
using Zenject;

namespace JobTest.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        public CharacterController CharacterController => _characterController;
        public PlayerStateData PlayerStateData { get; private set; }
        
        private IInputController _inputController;
        private IGameTime _gameTime;
        
        private IPlayerState _currentMovementState;
        private IPlayerState _currentAttackState;
        private ICameraController _cameraController;

        [Inject]
        public void Init(IInputController inputController, IGameTime gameTime, ICameraController cameraController)
        {
            _inputController = inputController;
            _gameTime = gameTime;
            _cameraController = cameraController;
        }
        
        private void Awake()
        {
            PlayerStateData = new PlayerStateData(this, _characterController, _inputController.InputControls, _gameTime, _cameraController);
            var initialMovementState = new PlayerGroundMovement(PlayerStateData);
            ChangeMovementState(initialMovementState);

            _currentAttackState = new PlayerShootState(PlayerStateData);
        }

        public void ChangeMovementState(IPlayerState newState)
        {
            _currentMovementState?.Exit();
            _currentMovementState = newState;
        }

        private void Update()
        {
            _currentMovementState?.Update();
            _currentAttackState?.Update();
        }
    }
}