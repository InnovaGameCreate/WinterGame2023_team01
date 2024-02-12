using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float MoveSpeed;
    private float RotetionSpeed;
    //[SerializeField] private float yRotetionSpeed = 80;
    private float xMoverange = 10;
    private float zMoverange = 10;
    private int count = 0;
    private bool allowMovement = true;
    private Rigidbody rb;
    private Collider colliderComponent;

    // Start is called before the first frame update
    void Start()
    {
        RotetionSpeed = 1;
        MoveSpeed = 1;
        countSet();
        rb = GetComponent<Rigidbody>();
        colliderComponent = GetComponent<Collider>();

        rb.useGravity = false;
    }

    void countSet()
    {
        CameraControl cameracontrol;
        GameObject obj = GameObject.Find("CameraControler");
        if (obj)
        {
            cameracontrol = obj.GetComponent<CameraControl>();
            count = cameracontrol.count;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Collider>().gameObject.tag == "Object" && allowMovement)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = true;
            allowMovement = false;
        }
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
            }

            float horizontalInput = 0;
            float verticalInput = 0;
            float xRotate = 1;
            float zRotate = 1;

            if (count == 0)
            {
                //デフォルトの移動
                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");
                zRotate = 0;
            }
            else if (count == 1)
            {
                horizontalInput = -Input.GetAxis("Vertical");
                verticalInput = Input.GetAxis("Horizontal");
                xRotate = 0;
            }
            else if (count == 2)
            {
                horizontalInput = -Input.GetAxis("Horizontal");
                verticalInput = -Input.GetAxis("Vertical");
                xRotate = -xRotate;
                zRotate = 0;
            }
            else if (count == 3)
            {
                horizontalInput = Input.GetAxis("Vertical");
                verticalInput = -Input.GetAxis("Horizontal");
                xRotate = 0;
                zRotate = -zRotate;
            }
            else
            {
                Debug.Log("count の値がおかしい。" + count);
            }

            if (zMoverange < this.transform.position.z && verticalInput > 0)
            {
                verticalInput = 0;
            }
            else if (-zMoverange > this.transform.position.z && verticalInput < 0)
            {
                verticalInput = 0;
            }
            else if (xMoverange < this.transform.position.x && horizontalInput > 0)
            {
                horizontalInput = 0;
            }
            else if (-xMoverange > this.transform.position.x && horizontalInput < 0)
            {
                horizontalInput = 0;
            }
            else
            {
                Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * MoveSpeed / 10;
                transform.Translate(movement, Space.World);
            }
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 rotate = new Vector3(xRotate, 0f, zRotate) * RotetionSpeed; 
                transform.Rotate(rotate, Space.World);
            }
            else if (Input.GetKey(KeyCode.RightShift))
            {
                Vector3 rotate = new Vector3(-zRotate, 0f, -xRotate) * RotetionSpeed;
                transform.Rotate(rotate, Space.World);
            }
        }
    }
}
