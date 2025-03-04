using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType {Straight, Spin}
    
    [Header("Bullet attributes")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float _bulletLife = 1f;
    [SerializeField] private float _speed = 1f;
    
    [Header("Spawner attributes")]
    [SerializeField] private SpawnerType _spawnerType;
    [SerializeField] private float _firingRate = 1f;
    
    private Bullet _spawnedBullet;
    private float _timer;

    void Start()
    {
        _spawnedBullet = GetComponent<Bullet>();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);

        if (_timer >= _firingRate)
        {
            Fire();
            _timer = 0;
        }
    }

    void Fire()
    {
        if (bulletPrefab)
        {
            _spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            _spawnedBullet._speed = _speed;
            _spawnedBullet._bulletLife = _bulletLife;
            _spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}