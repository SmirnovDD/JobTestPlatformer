using System.Collections.Generic;
using JobTest.CameraControl;
using JobTest.Enemy;
using JobTest.GamePlay;
using JobTest.Player;
using JobTest.UI;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace JobTest.Common.Infrastructure
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private WindowManager _windowManager;
        [SerializeField] private Vector3 _playerSpawnPoint;
        [SerializeField] private Vector3[] _enemySpawnPoints;
        
        public List<IEnemy> Enemies { get; } = new();
        public IPlayer Player { get; private set; }
        
        public override void InstallBindings()
        {
            BindGameController();
            BindWindowManager();
            BindCameraController();
            BindPlayer();
            BindEnemyFactory();
        }
        
        private void Awake()
        {
            SpawnEnemies();
        }
        
        private void BindGameController()
        {
            Container.Bind<IGameController>().To<GameController>().AsSingle();
        }
        
        private void BindWindowManager()
        {
            Container.Bind<IWindowManager>().FromInstance(_windowManager);
        }

        private void BindEnemyFactory()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }

        private void BindPlayer()
        {
            Player = Container.InstantiatePrefabForComponent<Player.Player>(_playerPrefab, _playerSpawnPoint, quaternion.identity, null);
            Container.Bind<IPlayer>().FromInstance(Player).AsSingle();
        }

        private void BindCameraController()
        {
            Container.Bind<ICameraController>().FromInstance(_cameraController).AsSingle();
        }
        
        private void SpawnEnemies()
        {
            var enemyFactory = Container.Resolve<IEnemyFactory>();
            enemyFactory.Load();
            foreach (var enemySpawnPoint in _enemySpawnPoints)
            {
                var enemy = enemyFactory.Spawn(enemySpawnPoint);
                Enemies.Add(enemy);
            }
        }
    }
}