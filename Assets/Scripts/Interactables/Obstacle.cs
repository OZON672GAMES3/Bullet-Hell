using Interactables;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPoolable
{
    public void OnGet()
    {
        gameObject.SetActive(true);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}
