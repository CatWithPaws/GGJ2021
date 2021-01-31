using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   
    void Update()
    {
		transform.RotateAround(transform.position, Vector3.forward,180 * Time.deltaTime);
    }
}
