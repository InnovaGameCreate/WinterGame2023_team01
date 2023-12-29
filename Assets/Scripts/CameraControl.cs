using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera1;
    [SerializeField] private Camera subCamera2;
    [SerializeField] private Camera subCamera3;
    public int count = 0;

    /*
    void ActiveMainCamera()
    {
        mainCamera.enabled = true;
        subCamera1.enabled = false;
        subCamera2.enabled = false;
        subCamera3.enabled = false;
    }

    void ActiveSubCamera1()
    {
        mainCamera.enabled = false;
        subCamera1.enabled = true;
        subCamera2.enabled = false;
        subCamera3.enabled = false;
    }

    void ActiveSubCamera2()
    {
        mainCamera.enabled = false;
        subCamera1.enabled = false;
        subCamera2.enabled = true;
        subCamera3.enabled = false;
    }
    
    void ActiveSubCamera3()
    {
        mainCamera.enabled = false;
        subCamera1.enabled = false;
        subCamera2.enabled = false;
        subCamera3.enabled = true;
    }*/
    void Start()
    {
        Debug.Log("Camera count:" + count);
        cameraSet();
        Debug.Log("Camera count:" + count);

    }
    void cameraSet()
    {
        mainCamera.depth = (count + 1) % 4;
        subCamera3.depth = (count + 2) % 4;
        subCamera2.depth = (count + 3) % 4;
        subCamera1.depth = count;

    }


    void Update()
    {
        // アクティブか非アクティブかで切り替え
        /*
        if(Input.GetKey(KeyCode.Space))
        {
            ActiveMainCamera();
            if(Input.GetKey(KeyCode.Space))
            {
                ActiveSubCamera1();
                if(Input.GetKey(KeyCode.Space))
                {
                    ActiveSubCamera2();
                    if(Input.GetKey(KeyCode.Space))
                    {
                        ActiveSubCamera3();
                    }
                }
            }
        }
        */

        // depthで切り替え
        // なんかバグる
        if(Input.GetKeyDown(KeyCode.Space))
        {
            count = (count+1)%4;
            cameraSet();
            Debug.Log("Camera count:" + count);


        }
    }
}
