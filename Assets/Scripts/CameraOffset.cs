using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setCameraOffset()
    {
        ObjectMaker objectmaker;
        GameObject obj = GameObject.Find("objectMaker");
        objectmaker = obj.GetComponent<ObjectMaker>();

        //Debug.Log("trasny:"+ transform.position.y);
        //Debug.Log("maxY:" + objectmaker.maxY);

        if((transform.position.y )< objectmaker.maxY + 11)
        {
            float x = transform.position.x;
            float y = objectmaker.maxY + 11;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        setCameraOffset();
    }
}
