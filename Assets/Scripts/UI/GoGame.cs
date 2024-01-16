using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
   
    [SerializeField] private float time;
    [SerializeField] private int fps;
    [SerializeField] private GameObject initial_object;
    [SerializeField] private Transform gogame_transform;
    private bool isStart = false;
    private Vector3 pos;
    private Vector3 rot;
    private float count = 1;
    //private Vector3 addVector = (gogame_transform.position - initial_object.transform.position)
    private void Start()
    {
        pos = (gogame_transform.position - initial_object.transform.position)/ (time * fps);
        rot = (gogame_transform.eulerAngles - initial_object.transform.eulerAngles) / (time * fps);

    }
    void Update()
    {
        // if(Input.GetKey(KeyCode.Return)) // エンターキーでMainシーンへ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            count = time * fps;
            isStart = true;
        }

        if (isStart && count > 0)
        {
            initial_object.transform.position += pos;
            initial_object.transform.eulerAngles += rot;
            count--;
        }
        if (count <= 0)
        {
            // スペースキーでMainシーンへ
            SceneManager.LoadScene("Stage");

        }

    }
}
