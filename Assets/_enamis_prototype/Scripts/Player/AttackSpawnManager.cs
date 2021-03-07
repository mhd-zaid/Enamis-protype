using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
   
    public class AttackSpawnManager : MonoBehaviour
    {
        private float speed = 5.0f;
        
        [SerializeField] public GameObject projectile;
       
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Instantiate(projectile);
                
                projectile.transform.Translate(Vector3.left * (Time.deltaTime * speed));
            }
        }
    }
}
