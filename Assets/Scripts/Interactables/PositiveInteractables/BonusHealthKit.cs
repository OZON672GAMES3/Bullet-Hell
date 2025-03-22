using ObjectPool;
using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusHealthKit : Interactable
    {
        private ObjectPool<BonusHealthKit> _objectPool;

        public void Initialize(ObjectPool<BonusHealthKit> objectPool)
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