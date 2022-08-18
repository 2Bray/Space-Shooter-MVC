using Agate.MVC.Base;
using UnityEngine;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public abstract class BulletController : ObjectController<BulletController, BulletView>
    {
        public bool ObjActive { get; private set; }

        public void InitController(BulletView view)
        {
            SetView(view);
            _view.InitObject(this, BulletCollide);
        }

        public void SpawnBullet(Vector2 pos)
        {
            _view.Launch(pos);
        }

        public void SetActive(bool b)
        {
            ObjActive = b;
        }

        public abstract void BulletCollide(Collider2D col);
    }
}