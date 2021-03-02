using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class LaserControl : MonoBehaviour
    {
        private int _tailleLaser = 3;
        public LineRenderer lineR;

        // Start is called before the first frame update
        void Start()
        {
            lineR = GetComponent<LineRenderer>();
            lineR.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            var transform1 = transform;
            Physics2D.Raycast(transform1.position, transform1.right, _tailleLaser);

            if (Input.GetButton("Fire1"))
            {
                // si il vas vers la droite
                lineR.enabled = true;
            }
            else
            {
                lineR.enabled = false;
            }
        }

    }
}

