using ObjectPool;
using UnityEngine;

namespace Interactables.NegativeInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class DamageMine : Interactable
    {
        private ObjectPool<DamageMine> _objectPool;

        public void Initialize(ObjectPool<DamageMine> objectPool)
        {
            _objectPool = objectPool;
        }

        protected override void Update()
        {
            base.Update();
            
            if (transform.position.y < -5)
                _objectPool.Release(this);
        }
    }
}