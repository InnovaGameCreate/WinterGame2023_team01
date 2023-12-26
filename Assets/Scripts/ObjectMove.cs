using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private int count;
    private bool allowMovement = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count += 1;
                if (count == 4) count = 0;
                Debug.Log("視点が切り替わる");
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = true;
                allowMovement = false;
                Debug.Log("移動が制御される");
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (count == 0)
            {
                //デフォルトの移動
            }
            if (count == 1)
            {
                float temp = horizontalInput;
                horizontalInput = -verticalInput;
                verticalInput = temp;
            }
            if (count == 2)
            {
                horizontalInput = -horizontalInput;
                verticalInput = -verticalInput;
            }
            if (count == 3)
            {
                float temp = horizontalInput;
                horizontalInput = verticalInput;
                verticalInput = -temp;
            }

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * MoveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
