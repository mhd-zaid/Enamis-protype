using System.Collections;
using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ------Constants ------
        private const float GravityModifier = 5.0f;
        
        // ------ References ------
        private Rigidbody2D _playerRigidbody2D;
        private GroundCheck _groundCheck;
        
        // ------ Private Attributes ------
        private float _speed = 15.0f;
        private float jumpForce = 900.0f;
        
        private bool _isOnGround; //Tells if the player is on the ground or not
        private bool _canJump = true; //In order to prevent jumping with continous pressing
        
        private float _horizontalInput;
        
        // ------ Public References------

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
            
            if (_isOnGround && _canJump &&Input.GetKey(KeyCode.Space))
                Jump();
            
            _horizontalInput = Input.GetAxis("Horizontal");
            Move();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_canJump && Input.GetKeyUp(KeyCode.Space))
                _canJump = true;
            
            //_horizontalInput = Input.GetAxis("Horizontal");
            //Move();
        }
        
        // ------- Basics Movements Methods -------
        
        /**
         * Moves the player in the wanted direction by the user
         */
        private void Move()
        {
            Vector3 newAngle = new Vector3(0, 0, -1.5f);
            _playerRigidbody2D.velocity = new Vector2(_speed * _horizontalInput, _playerRigidbody2D.velocity.y);
            
            transform.eulerAngles = newAngle * _horizontalInput; //WILL BECOME OBSOLETE AFTER CREATION OF SPRITE ANIMATOR
        }

        /**
         * Makes the player jump in the air
         */
        private void Jump()
        {
            _playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(nameof(JumpAnimationScale));
            _isOnGround = false;
            _canJump = false;
        }
        
        // ------- Collisions and Triggers Methods -------

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Token"))
            {
                Destroy(other.gameObject);
            }
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
    }
}