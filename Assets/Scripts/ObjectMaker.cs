using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] Tsumiki;
    [SerializeField] private GameObject[] Sonota;
    [SerializeField] float spawnOffset;//置かれたオブジェクトの最大値からの高さ
    [SerializeField] private float wait = 3;
    [SerializeField] private int player; 
    public float maxY = 0;
    bool objectMoving = true;
    bool canMake = true;
    public int count;
    private string targetTag = "Object";
    StageSelect stagemanager;
    GameObject obj;
    private int stage_num;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("StageManager");
        stagemanager = obj.GetComponent<StageSelect>();
        stage_num = stagemanager.stage_num;
        SpawnObject();
        count = 0;
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public float MaxY
    {
        get { return maxY; }
        set { maxY = value; }
    }

    void SpawnObject()
    {
        canMake = true;

        maxY = FindMaxY();

        if(maxY < 0)
        {
            maxY = 0;
        }

        Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);

        int random = 0;
      
        switch (stage_num) {
            case 0:
                random = Random.Range(0, Tsumiki.Length);
                GameObject tsumiki = Tsumiki[random];
                Instantiate(tsumiki, spawnPosition, tsumiki.transform.rotation);
                break;
            case 1:
                random = Random.Range(0, Sonota.Length);
                GameObject sonota = Sonota[random];
                Instantiate(sonota, spawnPosition, sonota.transform.rotation);
                break;
            default:
                random = Random.Range(0, Tsumiki.Length);
                GameObject def = Tsumiki[random];
                Instantiate(def, spawnPosition, def.transform.rotation);
                break;



        }

    }

    float FindMaxY()
    {
        float maxY = float.MinValue;

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objectsWithTag)
        {
            maxY = Mathf.Max(maxY, obj.transform.position.y);
        }

        return maxY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && canMake)
        {
            canMake = false;    
            StartCoroutine(WaitGenerateObject());
        }
    }

    IEnumerator WaitGenerateObject()
    {

        yield return new WaitForSeconds(wait);

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        
        foreach (GameObject obj in objectsWithTag)
        {
            Rigidbody objrb = obj.GetComponent<Rigidbody>();
            Debug.Log(objrb.velocity.magnitude);
            objectMoving = false;

            if (objrb != null && objrb.velocity.magnitude <= 0.01f)
            {
                objectMoving = true;
                Debug.Log("objectMoving True");
                break;
            }
        }

        if (objectMoving)
        {
            Debug.Log("新しいオブジェクトが生成される");
            SpawnObject();
            count++;
        }
        else
        {
            Debug.Log("オブジェクトがまだ動いている");
            StartCoroutine(WaitGenerateObject());
        }
    }
}
