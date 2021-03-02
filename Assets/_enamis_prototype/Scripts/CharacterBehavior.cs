using UnityEngine;

namespace _enamis_prototype.Scripts
{
    public class CharacterBehavior : MonoBehaviour
    {
        // ------Constants ------
       
        
        // ------ References ------
        
        
        // ------ Private Attributes ------
        
        
        // ------ Public Attributes ------
        
        private int _life = 10;
        
        // ------ Public References------
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                _life -= 5;
                if (_life <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
