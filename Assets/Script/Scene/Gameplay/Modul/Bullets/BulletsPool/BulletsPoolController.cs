using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public class BulletsPoolController : ObjectController<BulletsPoolController, BulletsPoolModel, IBulletsPool, BulletsPoolView>
    {
        public void InitController(BulletsPoolView view)
        {
            SetView(view);
            _model.InitPool(new List<BulletController>());

            for(int i=0; i<_view.SizePool; i++)
            {
                InstantiateNewOne();
            }
        }

        public void SpawnBullet(Vector2 pos)
        {
            foreach (BulletController bullet in _model.Pool)
            {
                if (!bullet.ObjActive)
                {
                    bullet.SpawnBullet(pos);
                    return;
                }

            }

            InstantiateNewOne();
        }

        private void InstantiateNewOne()
        {
            _model.Pool.Add(_view.InstantiateObjectPool().GetComponent<BulletView>().MyController);
            //_model.Pool[_model.Pool.Count - 1].InitController();
        }
    }
}