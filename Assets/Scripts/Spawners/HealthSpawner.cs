using System.Collections;
using Interactables.PositiveInteractables;
using ObjectPool;
using UnityEngine;

namespace Spawners
{
    public class HealthSpawner : MonoBehaviour
    {
        [SerializeField] private BonusHealthKit _bonusHealthKit;
        
        private RandomSpawn _randomSpawn;
        private ObjectPool<BonusHealthKit> _objectPool;

        public ObjectPool<BonusHealthKit> GetBonusHealthKitPool()
        {
            return _objectPool;
        }
        
        private void Awake()
        {
            _randomSpawn = GetComponentInParent<RandomSpawn>();
            _objectPool = new ObjectPool<BonusHealthKit>(_bonusHealthKit.GetComponent<BonusHealthKit>(), 1);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(30f);
            
            WaitForSeconds wait = new WaitForSeconds(30f);

            while (enabled)
            {
                BonusHealthKit healthKit = _objectPool.Get();
                healthKit.transform.position = _randomSpawn.RandomizeSpawnPosition();
                
                healthKit.Initialize(_objectPool);
                
                yield return wait;
            }
        }
    }
}