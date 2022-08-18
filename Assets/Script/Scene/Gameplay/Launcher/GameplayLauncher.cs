                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      using System.Collections;using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpaceShooter.Boot;
using SpaceShooter.Scene.Gameplay.Player;
using SpaceShooter.Scene.Gameplay.SpawnEnemy;
using SpaceShooter.Scene.Gameplay.InputManager;
using SpaceShooter.Scene.Gameplay.Bullet;

namespace SpaceShooter.Scene.Gameplay
{

    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";
        private PlayerController _playerController;
        private EnemySpawnController _enemySpawnController;
        private InputManagerController _inputManagerController;
        private BulletsPoolController _poolController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new PlayerConnector(),
                new BulletConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                 new PlayerController(),
                 new EnemySpawnController(),
                 new InputManagerController(),
                 new BulletsPoolController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _playerController.SetView(_view.player);
            _inputManagerController.InitController(_view.inputView);
            _enemySpawnController.Init(_view.enemySpawn);
            _poolController.InitController(_view.PoolBulletView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    
    }
}                                                                                                                                                                                        