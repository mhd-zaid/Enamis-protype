using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _playerRigidbody2D;
        
        private float _speed = 10f;
        private float _jumpForce = 10.0f;

        private bool _isOnGround = true;

        private float _horizontalInput;
        
        // Start is called before the first frame update
        void Start()
        {
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

        private void Move()
        {
            Vector3 newAngle = new Vector3(0, 0, -5);
            Transform transform1;
            
            (transform1 = transform).Translate(Vector3.right * (Time.deltaTime * _speed * _horizontalInput));
            transform1.eulerAngles = newAngle * _horizontalInput;
        }

        private void Jump()
        {
            _playerRigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            transform.localScale += new Vector3(0, -0.5f, 0);
            transform.localScale += new Vector3(0, 0.5f, 0);
            
            _isOnGround = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                _isOnGround = true;
        }
    }
}