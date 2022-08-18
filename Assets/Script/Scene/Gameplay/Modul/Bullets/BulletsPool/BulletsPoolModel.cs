using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public interface IBulletsPool : IBaseModel
    {
        public List<BulletController> Pool { get; }
    }

    public class BulletsPoolModel : BaseModel, IBulletsPool
    {
        public List<BulletController> Pool { get; private set; }

        public void InitPool(List<BulletController> pool)
        {
            Pool = pool;
        }

        public void SpawnObject ()
        {
            
        }
    }
}
