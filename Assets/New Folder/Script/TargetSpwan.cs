using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpwan : MonoBehaviour
{
    public static TargetSpwan instance;
    public GameObject targetPrefab;
    public float spwanTime = 1f;
    public int spwanCount = 3;
    public ParticleSystem destroyParticle;
    private BoxCollider spwanPos;
    private Vector3 excludingCenter;
    private Vector3 center;
    private Vector3 size;
    private Coroutine spwanStart;
    private Coroutine timer;
    private void Awake()
    {
        instance = this;
        spwanPos = GetComponent<BoxCollider>();
    }

    public void GameStart()
    {
        spwanStart = StartCoroutine(SpwanStart());
        timer = StartCoroutine(Timer());
    }

    public void GameEnd()
    {
        StopCoroutine(spwanStart);
        StopCoroutine(timer);
        TargetDestroy();
    }

    private void TargetDestroy()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            CanvasTest.instance.time -= 0.1f;
            CanvasTest.instance.Timer();
        }
    }

    private IEnumerator SpwanStart()
    {
        size = spwanPos.size;
        center = transform.position;
        center.y = 11.25f;
        excludingCenter = transform.position;
        while (true)
        {
            yield return new WaitForSeconds(spwanTime);
            for (int i = 0; i < spwanCount; i++)
            {
                GameObject target = Instantiate(targetPrefab);
                target.transform.position = RandomPos();
                RandomColor(target);
            }
        }
    }

    public void OBJDestroy(GameObject targetOBJ)
    {
        ParticleSystem par = Instantiate(destroyParticle);
        par.transform.position = targetOBJ.transform.position;
        par.Play();
        Destroy(par.gameObject, 0.3f);
        Destroy(targetOBJ);
    }

    private Vector3 RandomPos()
    {
        float randomX = RandomExcludingCenter(center.x - size.x / 2, center.x + size.x / 2, excludingCenter, -5f, 5f);
        float randomY = RandomExcludingCenter(center.y - size.y / 2, center.y + size.y / 2, excludingCenter, -5f, 5f);
        float randomZ = RandomExcludingCenter(center.z - size.z / 2, center.z + size.z / 2, excludingCenter, -5f, 5f);

        Vector3 randomPos = new Vector3(randomX, randomY, randomZ);

        return this.transform.position + randomPos;
    }

    private float RandomExcludingCenter(float min, float max, Vector3 refPos, float excludeMin, float excludeMax)
    {
        float randomVal = Random.Range(min, max);

        while (randomVal >= refPos.x + excludeMin && randomVal <= refPos.x + excludeMax)
        {
            randomVal = Random.Range(min, max);
        }

        return randomVal;
    }

    private void RandomColor(GameObject target)
    {
        //색별로 사이즈랑 점수바꾸기?
        int c = Random.Range(0, 5);
        switch(c)
        {
            case 0:
                target.GetComponent<Target>().Setting(Color.white, 1f, 10);
                break;
            case 1:
                target.GetComponent<Target>().Setting(Color.black, 0.9f, 15);
                break;
            case 2:
                target.GetComponent<Target>().Setting(Color.red, 0.8f, 20);
                break;
            case 3:
                target.GetComponent<Target>().Setting(Color.blue, 0.7f, 25);
                break;
            case 4:
                target.GetComponent<Target>().Setting(Color.yellow, 0.6f, 30);
                break;
            case 5:
                target.GetComponent<Target>().Setting(Color.green, 0.5f, 35);
                break;
            default:
                target.GetComponent<Target>().Setting(Color.gray, 0.4f, 40);
                break;
        }
    }

}
