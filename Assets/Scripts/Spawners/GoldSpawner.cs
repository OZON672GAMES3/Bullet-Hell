using System.Collections;
using Interactables.PositiveInteractables;
using ObjectPool;
using UnityEngine;

namespace Spawners
{
    public class GoldSpawner : MonoBehaviour
    {
        [SerializeField] private BonusGold _bonusGold;

        private RandomSpawn _randomSpawn;
        private ObjectPool<BonusGold> _objectPool;

        public ObjectPool<BonusGold> GetBonusGoldPool()
        {
            return _objectPool;
        }
        
        private void Awake()
        {
            _randomSpawn = GetComponentInParent<RandomSpawn>();
            _objectPool = new ObjectPool<BonusGold>(_bonusGold.GetComponent<BonusGold>(), 2);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(3f);
            
            WaitForSeconds wait = new WaitForSeconds(3f);

            while (enabled)
            {
                BonusGold bonusGold = _objectPool.Get();
                bonusGold.transform.position = _randomSpawn.RandomizeSpawnPosition();
                
                bonusGold.Initialize(_objectPool);
                
                yield return wait;
            }
        }
    }
}