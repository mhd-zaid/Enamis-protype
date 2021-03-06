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
        
        
        // Start is called before the first frame update
        void Start()
        {
            currentPosition = points[pointSelection];
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
        
        void Move()
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
