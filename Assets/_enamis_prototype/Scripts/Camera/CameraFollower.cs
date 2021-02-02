using UnityEngine;

namespace _enamis_prototype.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        private readonly Vector3 _offset = new Vector3(0, 2, -10);
    
        // Start is called before the first frame update
        void Start()
        {
        }

        // LateUpdate is called once per frame
        void LateUpdate()
        {
            transform.position += _offset;
        }

    }
}