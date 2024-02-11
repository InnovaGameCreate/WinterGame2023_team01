using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]private GameObject CanvasPrefab;
    //[SerializeField]private GameObject GoTitlePrefab; //要らなくね？
    [SerializeField]private GameObject CameraControler;
    private GameObject stageManager;

    private void Start()
    {
        stageManager = GameObject.Find("StageManager");

    }

    void OnCollisionEnter(Collision collision)
    {
        // Canvasプレハブをアクティブ
        Instantiate(CanvasPrefab);
        // シーン切り替えでResult表示
        // SceneManager.LoadScene("Result");

        // GoTitleを表示
        //Instantiate(GoTitlePrefab); //これもいらなくね？

        // CameraControlerを非アクティブ
        CameraControler.gameObject.SetActive(false);

        Destroy(stageManager);
        

        // Debug.Log("Hit");
    }
}
