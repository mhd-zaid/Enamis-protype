using System;
using UnityEngine;

namespace _enamis_prototype.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        // ------Constants ------
        private const float XPosBase = 0.0f;
        private const float YPosBase = 5.0f;
        private const float ZPosBase = -10.0f;
        
        // ------ References ------
        private Transform _playerTransform;
        private Transform _cameraTransform;

        // ------ Private Attributes ------
        private Vector3 _targetPosition = new Vector3(0, 0, 0);
        private readonly Vector3 _offset = new Vector3(XPosBase, YPosBase, ZPosBase);

        private FollowMode _followMode = FollowMode.Basic;
        
        private enum FollowMode
        {
            Basic,
            ReajustHeight,
            GoingDown
        }
        
        // ------ Event Methods ------

        // Start is called before the first frame update
        private void Awake()
        {
            _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
            _cameraTransform = transform;
        }

        private void Update()
        {
            _followMode = UpdateFollowMode();
        }

        // LateUpdate is called once per frame
        private void LateUpdate()
        {
            _targetPosition = _playerTransform.position + _offset;
            
            switch (_followMode)
            {
                case FollowMode.Basic:
                    _targetPosition.y = YPosBase;
                    break;
                case FollowMode.ReajustHeight:
                    _targetPosition.y = _playerTransform.position.y;
                    break;
                case FollowMode.GoingDown:
                    _targetPosition = _playerTransform.position + _offset;ui
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _cameraTransform.position = _targetPosition;
        }

        private FollowMode UpdateFollowMode()
        {
            // A REMPLACER PAR VALEUR SOL ET NOUVELLE VALEUR SOL PLUS TARD POUR SADAPTER 
            if (_playerTransform.position.y > 5)
            {
                Vector3.MoveTowards(_cameraTransform.position, _playerTransform.position, Single.MaxValue);
                return FollowMode.ReajustHeight;
            }

            if (_playerTransform.position.y < -1)
            {
                Vector3.MoveTowards(_cameraTransform.position, _playerTransform.position + _offset, Single.MaxValue);
                return FollowMode.GoingDown;
            }
            return FollowMode.Basic;
        }
    }
}