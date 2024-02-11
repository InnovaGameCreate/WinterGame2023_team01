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
    private GameObject canvas;

    private void Start()
    {
        stageManager = GameObject.Find("StageManager");
        canvas = GameObject.Find("Canvas");

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
        canvas.gameObject.SetActive(false); //プレイ中に表示されるテキストを非表示
        Destroy(stageManager);
        

        // Debug.Log("Hit");
    }
}
