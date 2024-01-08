using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]private GameObject CanvasPrefab;

    void OnCollisionEnter(Collision collision)
    {
      // プレハブでResult表示
      Instantiate(CanvasPrefab);
      // シーン切り替えでResult表示
      // SceneManager.LoadScene("Result");
      
      // Debug.Log("Hit");
    }
}
