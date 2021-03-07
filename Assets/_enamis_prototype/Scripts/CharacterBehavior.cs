using UnityEngine;

namespace _enamis_prototype.Scripts
{
    public class CharacterBehavior : MonoBehaviour
    {
        // ------Constants ------
       
        
        // ------ References ------
        
        
        // ------ Private Attributes ------
        
        
        // ------ Public Attributes ------
        
        [SerializeField] public int life = 10;
        
        // ------ Public References------
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                Destroy(other.gameObject);
                life -= 5;
                if (life <= 0)
                
                    Destroy(gameObject);
            }
        }
    }
}
