using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter.Scene.Gameplay.Bullet
{
    public class BulletsPoolView : ObjectView<IBulletsPool>
    {
        public int SizePool { get; private set; }
        [SerializeField] private GameObject obj;
        [SerializeField] private int size;


        public GameObject InstantiateObjectPool()
        {
            return Instantiate(obj);
        }

        protected override void InitRenderModel(IBulletsPool model)
        {

        }

        protected override void UpdateRenderModel(IBulletsPool model)
        {
            
        }
    }
}
