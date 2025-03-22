using UnityEngine;

namespace SceneMover
{
    public class TileMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;

        void Update()
        {
            transform.position += Vector3.down * (speed * Time.deltaTime);
            
            if (transform.position.y < -4.5f)
                transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        }
    }
}
