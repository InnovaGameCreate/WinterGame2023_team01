using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            count++;
            if (count == 4) count = 0;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (count == 0)
        {
            
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
