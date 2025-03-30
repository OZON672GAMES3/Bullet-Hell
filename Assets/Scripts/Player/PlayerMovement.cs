using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CapsuleCollider2D))]

    public class PlayerMovement : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        [SerializeField] private float _baseSpeed = 1;
    
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private CapsuleCollider2D _capsuleCollider;
    
        private float _horizontal;
        private float _vertical;
        private float _speedModifier;
        private float _slowMultiplier = 1f;

        private bool _isSlowed;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _capsuleCollider = GetComponent<CapsuleCollider2D>();
        }
    
        void Update()
        {
            Movement();
        }

        public void SetSpeedModifier(float speedModifier)
        {
            _speedModifier = speedModifier;
        }

        public void ApplySlow(float duration, float multiplier)
        {
            if (!_isSlowed)
            {

                _isSlowed = true;
                _slowMultiplier = multiplier;
                _speedModifier *= _slowMultiplier;
                StartCoroutine(SlowRoutine(duration));
            }
            else
            {
                StopCoroutine(SlowRoutine(duration));
                StartCoroutine(SlowRoutine(duration));
            }
        }

        private IEnumerator SlowRoutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            _speedModifier /= _slowMultiplier;
            _slowMultiplier = 1f;
            _isSlowed = false;
        }

        void Movement()
        {
            float speed = _baseSpeed * _speedModifier * _slowMultiplier;
            
            _horizontal = Input.GetAxisRaw(Horizontal) * speed * Time.deltaTime;
            _vertical = Input.GetAxisRaw(Vertical) * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _horizontal *= 0.5f;
                _vertical *= 0.5f;
            }

            Vector3 newPosition = transform.position + new Vector3(_horizontal, _vertical, 0f);

            newPosition.x = Mathf.Clamp(newPosition.x, -2.7f, 3f);
            newPosition.y = Mathf.Clamp(newPosition.y, -3.5f, 3.5f);
        
            transform.position = newPosition;
        }
    }
}
