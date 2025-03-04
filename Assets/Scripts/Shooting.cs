using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _bulletSpeed = 5f;

    void Start()
    {
        StartCoroutine(Shoot(_delayBetweenShots));
    }

    void Update()
    {
        
    }

    IEnumerator Shoot(float delayBetweenShots)
    {
        WaitForSeconds wait = new WaitForSeconds(delayBetweenShots);

        while (enabled)
        {
            Instantiate(_bulletPrefab, transform.position * _bulletSpeed, Quaternion.identity);

            yield return wait;
        }
    }
}