using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] float spawnOffset;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        float maxY = FindMaxY();

        Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    float FindMaxY()
    {
        float maxY = float.MinValue;

        foreach (Transform child in transform)
        {
            maxY = Mathf.Max(maxY, child.position.y);
        }

        return maxY;
    }
}
