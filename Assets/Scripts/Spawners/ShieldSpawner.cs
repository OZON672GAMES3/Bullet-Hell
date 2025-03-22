using System.Collections;
using Interactables.PositiveInteractables;
using ObjectPool;
using UnityEngine;

namespace Spawners
{
    public class ShieldSpawner : MonoBehaviour
    {
        [SerializeField] private BonusShield _bonusShield;
        
        private RandomSpawn _randomSpawn;
        private ObjectPool<BonusShield> _objectPool;

        public ObjectPool<BonusShield> GetBonusShieldPool()
        {
            return _objectPool;
        }
        
        private void Awake()
        {
            _objectPool = new ObjectPool<BonusShield>(_bonusShield.GetComponent<BonusShield>(), 1);
            _randomSpawn = GetComponentInParent<RandomSpawn>();
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(18f);
            
            WaitForSeconds wait = new WaitForSeconds(18f);

            while (enabled)
            {
                BonusShield shield = _objectPool.Get();
                shield.transform.position = _randomSpawn.RandomizeSpawnPosition();
                
                shield.Initialize(_objectPool);

                yield return wait;
            }
        }
    }
}