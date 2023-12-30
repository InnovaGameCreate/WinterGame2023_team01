using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] float spawnOffset;//置かれたオブジェクトの最大値からの高さ
    [SerializeField] private float wait;
    [SerializeField] private string targetTag = "Object";
    public float maxY = 0;
    bool objectMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        maxY = FindMaxY();

        if(maxY < 0)
        {
            maxY = 0;
        }

        Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);//変更中

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
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
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        objectMoving = false;

        foreach (GameObject obj in objectsWithTag)
        {
            Rigidbody objrb = obj.GetComponent<Rigidbody>();
            if (objrb != null && objrb.velocity.magnitude >= 0.1f)
            {
                objectMoving = true;
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {    
            StartCoroutine(WaitGenerateObject());

        }
    }

    IEnumerator WaitGenerateObject()
    {
        yield return new WaitForSeconds(wait);

        Debug.Log("新しいオブジェクトが生成される");
        SpawnObject();
    }

    //プログラムの問題点：Enterを連打するとオブジェクトが大量に生成される
    //原因：Enterを入力した時点での判定になるため，設置していないオブジェクトがある状態でもオブジェクトが生成される
    //解決案：Enterの入力をフラグにしてそのフラグの状態でオブジェクトを生成する
}
