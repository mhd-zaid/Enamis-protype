using UnityEngine;

namespace _enamis_prototype.Scripts.Platforms
{
    public class BouncyPlatforms : MonoBehaviour
    { 
        private const float BounceForce = 80.0f;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Rigidbody2D rgbd2D = other.gameObject.GetComponent<Rigidbody2D>();
            rgbd2D.AddForce(Vector2.up *  (rgbd2D.mass * BounceForce), ForceMode2D.Impulse);
        }
    }
}