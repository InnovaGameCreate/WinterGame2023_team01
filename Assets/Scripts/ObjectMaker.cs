using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] float spawnOffset;//置かれたオブジェクトの最大値からの高さ
    [SerializeField] private float wait = 3;
    [SerializeField] private int player; 
    public float maxY = 0;
    bool objectMoving = true;
    bool canMake = true;
    public int count;
    private string targetTag = "Object";

    // Start is called before the first frame update
    void Start()
    {
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

        int random = Random.Range(0, objectPrefabs.Length);
        GameObject select = objectPrefabs[random];

        Instantiate(select, spawnPosition, select.transform.rotation);

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
    }
}
