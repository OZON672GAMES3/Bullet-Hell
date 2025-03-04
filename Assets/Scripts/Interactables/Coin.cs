using Interactables;
using UnityEngine;

public class Coin : MonoBehaviour, IPoolable
{
    private IPoolable _poolableImplementation;

    public void OnGet()
    {
        gameObject.SetActive(true);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}
