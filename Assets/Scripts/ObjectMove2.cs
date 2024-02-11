using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove2 : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float xRotationSpeed = 50;
    [SerializeField] private float yRotationSpeed = 80;
    private bool allowMovement = true;
    private Rigidbody rb;
    Camera activeCamera;

    // Start is called before the first frame update
    void Start()
    {
        activeCamera = GetActiveCamera();
        MoveSpeed = 2;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (allowMovement)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = true;
                allowMovement = false;
                Debug.Log("移動が制御される");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // カメラ切り替え
                activeCamera = GetActiveCamera();
            }

            if (activeCamera != null)
            {
                Debug.Log("Active Camera: " + activeCamera.name);
                // カメラの向きを取得
                Vector3 cameraForward = activeCamera.transform.forward;
                Vector3 cameraRight = activeCamera.transform.right;

                // WASDによる移動
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                // カメラの向きに合わせて移動
                Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;
                transform.Translate(moveDirection * MoveSpeed * Time.deltaTime, Space.World);


                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    transform.Rotate(yRotationSpeed * Time.deltaTime * cameraForward);
                }
                else
                {
                    transform.Rotate(Vector3.up, xRotationSpeed * Time.deltaTime, Space.World);
                }
            }
        }
        else
        {
            Debug.Log("No active camera found.");
            // カメラが取得できなかった場合の処理
        }
    }

    Camera GetActiveCamera()
    {
        Camera[] allCameras = Camera.allCameras;
        foreach (var camera in Camera.allCameras)
        {
            if (camera != null && camera.gameObject.activeSelf)
            {
                Debug.Log(camera);
                return camera;
            }
        }

        return null;
    }
}
