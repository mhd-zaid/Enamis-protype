using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class GroundCheck : MonoBehaviour
    {
        private bool _groundCheck;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                _groundCheck = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                _groundCheck = false;
        }

        public bool isOnGround()
        {
            return _groundCheck;
        }
    }
}
