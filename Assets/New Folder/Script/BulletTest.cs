using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float bulletTime = 3f;

    private void Start()
    {
        StartCoroutine(BulletDestroy());
    }

    private void Update()
    {
        this.transform.Translate(this.transform.parent.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            CanvasTest.instance.BulletUpScore(other.gameObject.GetComponent<Target>().score);
            TargetSpwan.instance.OBJDestroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(bulletTime);
        Destroy(this.gameObject);
    }
}
