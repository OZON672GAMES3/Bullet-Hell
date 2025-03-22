using ObjectPool;
using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusGold : Interactable
    {
        [SerializeField] private int _goldValue = 10;
        
        private ObjectPool<BonusGold> _objectPool;

        public int GoldValue => _goldValue;

        public void Initialize(ObjectPool<BonusGold> objectPool)
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
