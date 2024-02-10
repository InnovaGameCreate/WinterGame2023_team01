using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField] public GameObject stageselect; // Textオブジェクト
    public int stage_num; // 変数
    [SerializeField] public string[] stages;

    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text Stage_text = stageselect.GetComponent<Text>();
        // テキストの表示を入れ替える
        Stage_text.text = stages[stage_num];

    }
}
