using System.Collections;
using UnityEngine;

namespace _enamis_prototype.Scripts.Platforms
{
    public class DestroyPlatfoms : MonoBehaviour
    {
        private bool _destroy = false;
        
        private void OnCollisionStay2D(Collision2D other)
        {
            _destroy = true;
            StartCoroutine(time());
            gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);

        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _destroy = false;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }

        IEnumerator time()
        {
            yield return new WaitForSeconds(2);
            if (_destroy)
                gameObject.SetActive(false);
        }
    }
}
