using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJOut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
        }
    }
}
