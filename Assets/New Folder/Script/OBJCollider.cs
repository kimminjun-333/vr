using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OBJCollider : MonoBehaviour
{
    private MeshCollider mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshCollider>();
        mesh.convex = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            CanvasTest.instance.ScoreUP(other.gameObject.GetComponent<Target>().score);
            TargetSpwan.instance.OBJDestroy(other.gameObject);
        }
    }
}
