using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] float spawnOffset;
    private bool objectMake = false;
    private Rigidbody rb;
    [SerializeField] private float wait;
    [SerializeField] private string targetTag = "Object";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SpawnObject();
    }

    void SpawnObject()
    {
        float maxY = FindMaxY();
        Debug.Log(maxY);

        if (maxY < 0)
        {
            Vector3 spawnPosition = new Vector3(0, spawnOffset, 0);
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(WaitGenerateObject());
            objectMake = false;
        }
    }

    IEnumerator WaitGenerateObject()
    {
        yield return new WaitForSeconds(wait);

        if (rb.velocity.magnitude < 0.01f && !objectMake)
        {
            objectMake = true;
            Debug.Log("新しいオブジェクトが生成される");
            SpawnObject();
        }
    }
}
