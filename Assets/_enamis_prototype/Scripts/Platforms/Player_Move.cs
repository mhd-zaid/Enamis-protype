using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        other.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = null;
    }
}
