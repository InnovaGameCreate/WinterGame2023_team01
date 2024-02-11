using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    public void GoTitlef()
    {
        SceneManager.LoadScene("Title");
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) GoTitlef(); //spaceまたはreturnでタイトルに戻る
        if (Input.GetKeyDown(KeyCode.Space)) GoTitlef(); //spaceでタイトルに戻る
    }
}
