using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));

        // if (transform.position.y < -10f)
            // Destroy(gameObject);
    }
}
