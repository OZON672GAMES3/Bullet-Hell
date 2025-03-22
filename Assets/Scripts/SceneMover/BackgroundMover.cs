using UnityEngine;

namespace SceneMover
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;

        void Update()
        {
            transform.position += Vector3.down * (speed * Time.deltaTime);

            if (transform.position.y < -10)
                transform.position = new Vector3(transform.position.x, 11f, transform.position.z);
        }
    }
}
