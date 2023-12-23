using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera1;
    [SerializeField] private Camera subCamera2;
    [SerializeField] private Camera subCamera3;

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
    }
    void Start()
    {
        mainCamera = Camera.main;
    }
    */

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
        if(Input.GetKey(KeyCode.Space))
        {
            if(mainCamera.depth < 0)
            {
                mainCamera.depth = 0;
                subCamera1.depth = -1;
            }
            else if(subCamera1.depth < 0)
            {
                subCamera1.depth = 0;
                subCamera2.depth = -1;
            }
            else if(subCamera2.depth < 0)
            {
                subCamera2.depth = 0;
                subCamera3.depth = -1;
            }
            else if(subCamera3.depth < 0)
            {
                mainCamera.depth = -1;
                subCamera3.depth = 0;
            }
        }
    }
}
