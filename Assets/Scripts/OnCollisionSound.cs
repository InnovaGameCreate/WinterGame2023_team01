using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnCollisionSound : MonoBehaviour
{
    [SerializeField] private string[] collisionObjectTags;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool isCollision = false;
        foreach(string str in collisionObjectTags)
        {
            if (str == collision.gameObject.tag) isCollision = true;
        }
        if(isCollision) GetComponent<AudioSource>().Play();
    }
}
