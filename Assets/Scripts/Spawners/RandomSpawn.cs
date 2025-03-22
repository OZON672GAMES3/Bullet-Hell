using UnityEngine;

namespace Spawners
{
    public class RandomSpawn : MonoBehaviour
    {
        public Vector3 RandomizeSpawnPosition()
        {
            float x = Random.Range(-2.7f, 3f);
            return new Vector3(x, 5, 0);
        }
    }
}