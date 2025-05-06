using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float _speed;
    [Header("Jumping")]
    [SerializeField] private float _maxFlyTime;
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _footPos;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJumping;

    private float currentFlyTime;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * _speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void HandleJump()
    {
        _isGrounded = Physics2D.OverlapCircle(_footPos.position, _radius, _ground);
        float verticalInput = Input.GetAxisRaw("Vertical");

        // якщо гравець торкаЇтьс€ земл≥ та не стрибаЇ
        if (_isGrounded && !_isJumping)
        {
            currentFlyTime = 0f;

            if (verticalInput > 0)
            {
                _isJumping = true;
            }
        }
        // якщо гравець стрибаЇ
        if (_isJumping)
        {
            if (verticalInput > 0 && currentFlyTime <= _maxFlyTime)
            {
                rb.velocity = new Vector2(rb.velocity.x, _force * Time.fixedDeltaTime);
                currentFlyTime += Time.fixedDeltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
    }

    private bool CanJump()
    {
        //якщо гравець торкаЇтьс€ земл≥ та не намагаЇтьс€ стрибати
        return _isGrounded && Input.GetAxisRaw("Vertical") <= 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>() != null && CanJump())
        {
            _isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_footPos.position, _radius);
    }
}
