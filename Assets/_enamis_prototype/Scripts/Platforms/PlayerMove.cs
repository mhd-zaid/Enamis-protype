using UnityEngine;

namespace _enamis_prototype.Scripts.Platforms
{
    public class PlayerMove : MonoBehaviour
    {
        private void OnCollisionStay2D(Collision2D other)
        {
            other.transform.parent = transform;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            other.transform.parent = null;
        }
    }
}
