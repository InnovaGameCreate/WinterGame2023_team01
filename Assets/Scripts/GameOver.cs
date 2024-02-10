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
      // Canvasプレハブをアクティブ
      Instantiate(CanvasPrefab);
      // シーン切り替えでResult表示
      // SceneManager.LoadScene("Result");

      // GoTitleを表示
      Instantiate(GoTitlePrefab);

      // CameraControlerを非アクティブ
      CameraControler.gameObject.SetActive(false);

      // Debug.Log("Hit");
    }
}
