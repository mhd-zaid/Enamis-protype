using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace _enamis_prototype.Scripts.Platforms
{
    public class MovingPlatforms : MonoBehaviour
    {
        public GameObject platform;
        public float speed;
        public Transform currentPosition;
        public Transform[] points;
        public int pointSelection;
		private bool moving;
        private Vector3 velocity;
        
        
        // Start is called before the first frame update
        void Start()
        {
            currentPosition = points[pointSelection];
        }

        // Update is called once per frame
        void Update()
        {
            Move(this.gameObject);
        }
        
        void Move(GameObject gameObject)
        {
            platform.transform.position = Vector3.MoveTowards
            (platform.transform.position, currentPosition.position,
                speed * Time.deltaTime);
            if (platform.transform.position == currentPosition.position)
            {
                pointSelection++;
                if (pointSelection == points.Length)
                {
                    pointSelection = 0;
                }

                currentPosition = points[pointSelection];
            }
        }
    }
}
