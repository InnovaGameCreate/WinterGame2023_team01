using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) // スペースキーでMainシーンへ
        // if(Input.GetKey(KeyCode.Return)) // エンターキーでMainシーンへ
            SceneManager.LoadScene("Main");
    }
}
