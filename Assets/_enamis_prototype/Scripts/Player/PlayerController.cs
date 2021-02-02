using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float _speed = 0.2f;
        private float _jumpForce = 1.0f;

        private bool isAlive = true;
        private bool isOnGround;
        private bool isDashing;

        private float _horizontalInput;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // FixedUpdate is called once per frame
        void FixedUpdate()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * (_speed * _horizontalInput));
        }
    }
}