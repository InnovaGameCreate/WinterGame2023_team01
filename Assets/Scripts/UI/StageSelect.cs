using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StageSelect : MonoBehaviour
{
    [SerializeField] public GameObject stageselect; // Textオブジェクト
    public int stage_num; // 変数
    [SerializeField] public string[] stages;

    // Update is called once per frame
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Title") DontDestroyOnLoad(this);
        DispText();

    }
    public void DispText()
    {
        // オブジェクトからTextコンポーネントを取得
        TextMeshProUGUI Stage_text = stageselect.GetComponent<TextMeshProUGUI>();
        // テキストの表示を入れ替える
        Stage_text.text = stages[stage_num];

    }
}
