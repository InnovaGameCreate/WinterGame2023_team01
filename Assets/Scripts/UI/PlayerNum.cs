using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    
    public GameObject num = null; // Textオブジェクト
    [SerializeField] public int player_max_num;
    public int player_num = 0; // 変数
    [SerializeField] string playerText;
    private TextMeshProUGUI Player_text;

    // Update is called once per frame
    private void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        Player_text = num.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
       
        // テキストの表示を入れ替える
        Player_text.text = playerText + "：" + player_num;

    }
}
