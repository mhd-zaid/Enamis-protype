using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
    public class AttackSpawnManager : MonoBehaviour
    {
        [SerializeField] public GameObject projectile;

        // Update is called once per frame
        public void SpawnProjectile()
        {
            var transform1 = transform;
            Instantiate(projectile, transform1.position, transform1.rotation);
        }
    }
}
