using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatfoms : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    private bool _destroy;
    void Start()
    {
        platform.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        _destroy = true;
        StartCoroutine(time());
        platform.GetComponent<Renderer>().material.SetColor("_Color",Color.red);

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _destroy = false;
        platform.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(3);
        if (_destroy != false)
        {
            platform.SetActive(false);
        }
        
    }
}
