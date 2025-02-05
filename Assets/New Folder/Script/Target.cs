using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Color color;
    public Vector3 size;
    public int score;

    public void Setting(Color color, float size, int score)
    {
        this.color = color;
        this.size = new Vector3(size, size, size);
        this.score = score;
        GetComponent<MeshRenderer>().material.color = this.color;
        this.gameObject.transform.localScale = this.size;
    }
}
