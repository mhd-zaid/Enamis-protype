using UnityEngine;

public class MoveForward : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * 20));
    }
}
