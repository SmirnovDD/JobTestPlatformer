using System;
using JobTest.CameraControl;
using JobTest.Events;
using JobTest.GamePlay;
using JobTest.Misc;
using JobTest.Time;
using JobTest.UI;
using UnityEngine;
using Zenject;

namespace JobTest.Common.Infrastructure
{
    public class LevelInitializer : MonoBehaviour
    {
        private ICameraController _cameraController;
        private IGameController _gameController;
        private AppearOnEnemiesDead _appearOnEnemiesDeadKey;
        private AppearOnKeyTaken _appearOnKeyCollectedDoor;
        private LevelInstaller _levelInstaller;
        private Key _key;

        [Inject]
        public void Init(ICameraController cameraController, IGameController gameController)
        {
            _cameraController = cameraController;
            _gameController = gameController;
        }
        
        private void Awake()
        {
            //TODO refactor with zenject
            _levelInstaller = FindObjectOfType<LevelInstaller>();
            _appearOnEnemiesDeadKey = FindObjectOfType<AppearOnEnemiesDead>();
            _appearOnKeyCollectedDoor = FindObjectOfType<AppearOnKeyTaken>();
            _key = FindObjectOfType<Key>();
            _gameController.OnGameStart();
        }

        private void Start()
        {
            SetCameraTarget();
            SetEventForKey();
            SetEventForDoor();
        }
        
        private void SetCameraTarget() 
        {
            _cameraController.SetTargetToFollow(_levelInstaller.Player.Transform);
        }
        
        private void SetEventForKey()
        {
            _appearOnEnemiesDeadKey.Set(_levelInstaller.Enemies);
        }

        private void SetEventForDoor()
        {
            _appearOnKeyCollectedDoor.Set(_key);
        }
    }
}