using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _bulletLife;
    [SerializeField] public float _speed;
    [SerializeField] private float _rotation;

    private Vector2 _spawnPont;
    private float _timer;

    void Start()
    {
        _spawnPont = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (_timer > _bulletLife) Destroy(gameObject);
            _timer += Time.deltaTime;

        transform.position = Movement(_timer);
    }

    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * _speed * transform.right.x;
        float y = timer * _speed * transform.right.y;
        return new Vector2(x + _spawnPont.x, y + _spawnPont.y);
    }
}