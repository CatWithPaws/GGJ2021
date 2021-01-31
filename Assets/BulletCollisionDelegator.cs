using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDelegator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent.gameObject.GetComponent<BulletInfoBehaviour>().OnTriggerEnter2D(other);
    }
}
