using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public class EnemyBullet : BulletController
    {
        public override void BulletCollide(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                
            }
            else if (col.CompareTag("Wall"))
            {
                col.gameObject.SetActive(false);
            }
            else if (col.CompareTag("EndLine"))
            {

            }
            else return;
        }
    }
}