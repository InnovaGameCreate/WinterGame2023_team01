using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerNum : MonoBehaviour
{
    
    public GameObject num= null; // Textオブジェクト
    public int player_num = 0; // 変数

    // Update is called once per frame
    void Update()
    {
         // オブジェクトからTextコンポーネントを取得
        Text Player_text = num.GetComponent<Text> ();
             // テキストの表示を入れ替える
     Player_text.text = "Player:" + player_num;

    }
}
