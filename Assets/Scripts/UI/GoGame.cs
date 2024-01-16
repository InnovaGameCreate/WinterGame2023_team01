using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // スペースキーでMainシーンへ
        {
              SceneManager.LoadScene("Stage");
        }
         if(Input.GetKey(KeyCode.Return)) // エンターキーでMainシーンへ
            SceneManager.LoadScene("Stage");
    }
}
