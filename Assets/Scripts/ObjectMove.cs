using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1;
    [SerializeField] private float xRotetionSpeed = 50;
    [SerializeField] private float yRotetionSpeed = 80;


    private int count = 0;
    private bool allowMovement = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        countSet();
        Debug.Log("count:" + count);

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void countSet()
    {
        CameraControl cameracontrol;
        GameObject obj = GameObject.Find("CameraControler");
        cameracontrol = obj.GetComponent<CameraControl>();
        count = cameracontrol.count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count = (count + 1) % 4;
        }

        if (allowMovement)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = true;
                allowMovement = false;
                Debug.Log("移動が制御される");
            }

            float horizontalInput = 0;
            float verticalInput = 0;

            if (count == 0)
            {
                //デフォルトの移動
                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");
            }else 
            if (count == 1)
            {
                horizontalInput = -Input.GetAxis("Vertical");
                verticalInput = Input.GetAxis("Horizontal");
            }else
            if (count == 2)
            {
                horizontalInput = -Input.GetAxis("Horizontal");
                verticalInput = -Input.GetAxis("Vertical");
            }
            else
            if (count == 3)
            {
                horizontalInput = Input.GetAxis("Vertical");
                verticalInput = -Input.GetAxis("Horizontal");
            }
            else
            {
                Debug.Log("count の値がおかしい。" + count);
            }

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * MoveSpeed / 10;
            transform.Translate(movement,Space.World);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.Rotate(Vector3.right, yRotetionSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Rotate(Vector3.up, xRotetionSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
