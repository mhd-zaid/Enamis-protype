using UnityEngine;

namespace _enamis_prototype.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;

        private Vector3 _targetPosition;
        private readonly Vector3 _offset = new Vector3(0, 2, -10);

        // Start is called before the first frame update
        void Start()
        {
            _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
            _cameraTransform = transform;
        }

        // LateUpdate is called once per frame
        void LateUpdate()
        {
            _targetPosition = _playerTransform.position + _offset;
            _cameraTransform.position = _targetPosition;
        }
    }
}