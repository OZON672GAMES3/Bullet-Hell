using System.Collections;
using Interactables.NegativeInteractables;
using ObjectPool;
using UnityEngine;

namespace Spawners
{
    public class MinesSpawner : MonoBehaviour
    {
        [SerializeField] private DamageMine _damageMine;
        
        private RandomSpawn _randomSpawn;
        private ObjectPool<DamageMine> _objectPool;

        public ObjectPool<DamageMine> GetDamageMinePool()
        {
            return _objectPool;
        }
        
        private void Awake()
        {
            _randomSpawn = GetComponentInParent<RandomSpawn>();
            _objectPool = new ObjectPool<DamageMine>(_damageMine.GetComponent<DamageMine>(), 6);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            WaitForSeconds wait = new WaitForSeconds(1f);

            while (enabled)
            {
                DamageMine damageMine = _objectPool.Get();
                damageMine.transform.position = _randomSpawn.RandomizeSpawnPosition();
                
                damageMine.Initialize(_objectPool);

                yield return wait;
            }
        }
    }
}
