using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public class BulletView : BaseView
    {
        public BulletController MyController { get; private set; }

        private UnityAction<Collider2D> onCollide;
        private Rigidbody2D rb;


        public void Launch(Vector2 dir)
        {
            rb.velocity = dir;
        }

        public void InitObject(BulletController ctr, UnityAction<Collider2D> action)
        {
            MyController = ctr;
            onCollide = action;
            rb = GetComponent<Rigidbody2D>();
            DeAktive();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            onCollide(collision);
            DeAktive();
        }

        private void DeAktive()
        {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
