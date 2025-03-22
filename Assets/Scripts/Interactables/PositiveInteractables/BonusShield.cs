using ObjectPool;
using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusShield : Interactable
    {
        private ObjectPool<BonusShield> _objectPool;

        public void Initialize(ObjectPool<BonusShield> objectPool)
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