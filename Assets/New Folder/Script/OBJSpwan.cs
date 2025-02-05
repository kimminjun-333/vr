using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJSpwan : MonoBehaviour
{
    public static OBJSpwan instance;
    public GameObject[] objPrefab;
    public Transform OBJSpwanPos;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (GameObject a in objPrefab)
        {
            a.AddComponent<OBJCollider>();
        }
    }

    public void Spwan()
    {
        int a = Random.Range(0, objPrefab.Length);
        GameObject OBJ = Instantiate(objPrefab[a]);
        OBJ.gameObject.transform.position = OBJSpwanPos.position;
    }
}
