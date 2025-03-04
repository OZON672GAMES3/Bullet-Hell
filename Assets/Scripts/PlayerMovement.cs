using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider;
    
    private float _horizontal;
    private float _vertical;

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

    void Movement()
    {
        _horizontal = Input.GetAxis(Horizontal) * _speed * Time.deltaTime;
        _vertical = Input.GetAxis(Vertical) * _speed * Time.deltaTime;

        transform.Translate(new Vector3(_horizontal, _vertical));
    }
}