using UnityEngine;

namespace SceneMover
{
    public class BackgroundMover : ObjectMover
    {
        protected override void Move()
        {
            transform.position += Vector3.down * (_speed * Time.deltaTime);
        }

        protected override void GetResetPosition()
        {
            if (transform.position.y < -10)
                transform.position = new Vector3(transform.position.x, 11f, transform.position.z);
        }
    }
}
