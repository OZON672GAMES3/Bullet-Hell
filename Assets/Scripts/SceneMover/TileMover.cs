using UnityEngine;

namespace SceneMover
{
    public class TileMover : ObjectMover
    {
        protected override void Move()
        {
            transform.position += Vector3.down * (_speed * Time.deltaTime);
        }

        protected override void GetResetPosition()
        {
            if (transform.position.y < -4.5f)
                transform.position = new Vector3(transform.position.x, _resetPositionY, transform.position.z);
        }
    }
}
