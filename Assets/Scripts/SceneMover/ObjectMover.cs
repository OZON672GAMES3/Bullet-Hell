using UnityEngine;

namespace SceneMover
{
    public abstract class ObjectMover : MonoBehaviour
    {
        [SerializeField] protected float _speed = 1f;
        [SerializeField] protected float _resetPositionY = 5.5f;

        protected virtual void Update()
        {
            Move();
            GetResetPosition();
        }

        protected abstract void Move();

        protected virtual void GetResetPosition()
        {
            if (transform.position.y < -4.5f)
                transform.position = new Vector3(transform.position.x, _resetPositionY, transform.position.z);
        }
    }
}