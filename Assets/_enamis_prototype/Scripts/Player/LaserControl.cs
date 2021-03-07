using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class LaserControl : MonoBehaviour
    {
        private int _tailleLaser = 3;
        
        // Update is called once per frame
        void Update()
        {
            var transform1 = transform;
            Physics2D.Raycast(transform1.position, transform1.right, _tailleLaser);

            if (Input.GetKey(KeyCode.S))
            {
                // si il vas vers la droite
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
        }

    }
}

