using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

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
            //Debug.Log("count:" + count);
            count = (count + 1) % 4;
            //Debug.Log("視点が切り替わる");
            //Debug.Log("count:" + count);
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
            //Debug.Log(Input.GetAxis("Horizontal"));

            //Debug.Log(count);

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
            transform.Translate(movement);
        }
    }
}
