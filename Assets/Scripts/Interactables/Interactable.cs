using ObjectPool;
using UnityEngine;

namespace Interactables
{
    public abstract class Interactable<T> : MonoBehaviour where T : MonoBehaviour
    {
        private ObjectPool<T> _objectPool;

        public void Init(ObjectPool<T> objectPool)
        {
            _objectPool = objectPool;
        }
        
        private void Move()
        {
            transform.position += Vector3.down * (2 * Time.deltaTime);

            if (transform.position.y < -5)
                _objectPool.Release((T)(object)this);
                
        }

        protected virtual void Update()
        {
            Move();
        }
    }
}