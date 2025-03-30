using System.Collections;
using ObjectPool;
using UnityEngine;

namespace Spawners
{
    public abstract class GenericSpawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private int _initialSize;
        [SerializeField] private float _spawnDelay;
        
        private ObjectPool<T> _objectPool;
        private RandomSpawn _randomSpawn;

        protected virtual void Awake()
        {
            _randomSpawn = GetComponentInParent<RandomSpawn>();
            _objectPool = new ObjectPool<T>(_prefab, _initialSize);
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            yield return new WaitForSeconds(_spawnDelay);
            
            WaitForSeconds wait = new WaitForSeconds(_spawnDelay);
            
            while (enabled)
            {
                T obj = _objectPool.Get();
                obj.transform.position = _randomSpawn.RandomizeSpawnPosition();
                InitObject(obj);
                
                yield return wait;
            }
        }

        protected abstract void InitObject(T obj);

        public ObjectPool<T> GetObjectPool()
        {
            return _objectPool;
        }
    }
}