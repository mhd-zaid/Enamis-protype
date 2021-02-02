using System.Collections;
using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        //Constants
        private const float GravityModifier = 3.5f;
        
        //References
        private Rigidbody2D _playerRigidbody2D;
        
        //Private Attributes
        private float _speed = 10f;
        private float _jumpForce = 550.0f;

        [SerializeField] private bool _isOnGround = true;

        private float _horizontalInput;
        
        // Start is called before the first frame update
        void Start()
        {
            Physics2D.gravity *= GravityModifier;
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
        }

        // FixedUpdate is called once per frame
        void FixedUpdate()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

            Move();
            
            if (_isOnGround && Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        //Basics Movements Methods
        private void Move()
        {
            Vector3 newAngle = new Vector3(0, 0, -5);
            Transform transform1;
            
            (transform1 = transform).Translate(Vector3.right * (Time.deltaTime * _speed * _horizontalInput));
            transform1.eulerAngles = newAngle * _horizontalInput; //WILL BECOME OBSOLETE AFTER CREATION OF SPRITE ANIMATOR
        }

        private void Jump()
        {
            _playerRigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            StartCoroutine(nameof(JumpAnimationScale));
            _isOnGround = false;
        }

        
        //Collisions and Triggers Methods
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                _isOnGround = true;
        }
        
        //Coroutines Methodes
        
        /**
         * WILL BECOME OBSOLETE AFTER CREATION OF SPRITE ANIMATOR
         */
        IEnumerator JumpAnimationScale()
        {
            transform.localScale += new Vector3(0, -0.2f, 0);
            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0, 0.2f, 0);
        }
    }
}