using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]private GameObject CanvasPrefab;
    [SerializeField]private GameObject GoTitlePrefab;
    [SerializeField]private GameObject CameraControler;


    void OnCollisionEnter(Collision collision)
    {
      // プレハブでResult表示
      Instantiate(CanvasPrefab);
      // シーン切り替えでResult表示
      // SceneManager.LoadScene("Result");

      // GoTitleを表示
      Instantiate(GoTitlePrefab);

      // CameraControlerを削除
      Destroy(CameraControler);

      // Debug.Log("Hit");
    }
}
