using UnityEngine;

namespace SceneMover
{
    public abstract class ObjectMover : MonoBehaviour
    {
        [SerializeField] protected float _speed = 1f;
        [SerializeField] protected float _resetPositionY = 5.5f;
        [SerializeField] protected float _resetTriggerHeight = -4.5f;

        protected virtual void Update()
        {
            Move();
            GetResetPosition();
        }

        private void Move()
        {
            transform.position += Vector3.down * (_speed * Time.deltaTime);
        }

        private void GetResetPosition()
        {
            if (transform.position.y < _resetTriggerHeight)
                transform.position = new Vector3(transform.position.x, _resetPositionY, transform.position.z);
        }
    }
}