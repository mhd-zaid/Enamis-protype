using System.Collections;
using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ------Constants ------
        private const float GravityModifier = 4.5f;
        private const float MaxFallSpeed = 35.0f;
        
        // ------ References ------
        private Rigidbody2D _playerRigidbody2D;
        private GroundCheck _groundCheck;
        
        // ------ Private Attributes ------
        private readonly Vector3 _defaultPosition = new Vector3(0, 3, 0);
        
        private float _speed = 15.0f;
        private float _jumpForce = 1000.0f;
        private float _projectileSpeed = 5.0f;

        private bool _canAttack = true;

        [Range(0, 2)] private int _jumpCount;
        
        private bool _isOnGround; //Tells if the player is on the ground or not
        private bool _canJump = true; //In order to prevent jumping with continous pressing
        private bool _canDoubleJump = true;
        
        private float _horizontalInput;
        
        // ------ Public References------
        [SerializeField] public GameObject projectile;

        // ------ Event Methods ------

        private void Awake()
        {
            //Initializing References
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _groundCheck = GameObject.Find("Ground Check").GetComponent<GroundCheck>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            //Initializing Physics Properties
            Physics2D.gravity *= GravityModifier;
        }
        
        // FixedUpdate is called once per frame
        private void FixedUpdate()
        {
            _isOnGround = _groundCheck.isOnGround();
            
            _jumpCount = _isOnGround switch
            {
                true => 0,
                false when _jumpCount == 0 => 1,
                _ => _jumpCount
            };

            switch (_jumpCount)
            {
                case 0:
                    if (_isOnGround && _canJump && Input.GetKey(KeyCode.Space))
                        Jump();
                    break;
                case 1:
                    if (_canDoubleJump && _canJump && Input.GetKey(KeyCode.Space))
                        Jump();
                    break;
            }

            _horizontalInput = Input.GetAxis("Horizontal");
            Move();

            if (_playerRigidbody2D.velocity.y > MaxFallSpeed)
                SetPlayerVelocity(_playerRigidbody2D.velocity.x, MaxFallSpeed);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_canJump && Input.GetKeyUp(KeyCode.Space))
            {
                _canJump = true;
            }
            
            if (Input.GetKey(KeyCode.Z) && _canAttack)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                StartCoroutine(AttackDelay());
            }

            if (transform.position.y < -20)
            {
                transform.localPosition = _defaultPosition;
                SetPlayerVelocity(0, 0);
            }
        }
        
        // ------- Basics Movements Methods -------
        
        /**
         * Moves the player in the wanted direction by the user
         */
        private void Move()
        {
            SetPlayerVelocity(_speed * _horizontalInput, _playerRigidbody2D.velocity.y);
        }

        /**
         * Makes the player jump in the air
         */
        private void Jump()
        {
            SetPlayerVelocity(_playerRigidbody2D.velocity.x, 0);
            _playerRigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            StartCoroutine(nameof(JumpAnimationScale));
            _isOnGround = false;
            _canJump = false;
            ++_jumpCount;
        }

        private void SetPlayerVelocity(float x, float y)
        {
            _playerRigidbody2D.velocity = new Vector2(x, y);
        }
        
        
        // ------- Collisions and Triggers Methods -------
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                SetPlayerVelocity(_playerRigidbody2D.velocity.x, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Token"))
                Destroy(other.gameObject);
        }

        // ------- Coroutines Methods -------
        
        /**
         * WILL BECOME OBSOLETE AFTER CREATION OF SPRITE ANIMATOR
         */
        private IEnumerator JumpAnimationScale()
        {
            transform.localScale += new Vector3(0, -0.5f, 0);
            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0, 0.5f, 0);
        }

        private IEnumerator AttackDelay()
        {
            _canAttack = false;
            yield return new WaitForSeconds(0.5f);
            _canAttack = true;
        }
    }
}