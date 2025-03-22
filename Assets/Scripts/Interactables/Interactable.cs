using UnityEngine;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        private void Move()
        {
            transform.position += Vector3.down * (2 * Time.deltaTime);
        }

        protected virtual void Update()
        {
            Move();
        }
    }
}