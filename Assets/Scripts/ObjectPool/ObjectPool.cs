using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Queue<T> _pool = new Queue<T>();
        private readonly Transform _parent;

        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = Object.Instantiate(_prefab, parent);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public T Get(System.Action<T> onGet = null)
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : Object.Instantiate(_prefab, _parent);
            
            obj.gameObject.SetActive(true);
            onGet?.Invoke(obj);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}
