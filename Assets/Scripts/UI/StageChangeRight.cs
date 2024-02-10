using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChangeRight : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        StageSelect stagemanager;
        GameObject obj = GameObject.Find("StageManager");
        stagemanager = obj.GetComponent<StageSelect>(); //付いているスクリプトを取得
                                           // ボタンが押されたら人数を一つ増す

        stagemanager.stage_num = (stagemanager.stage_num + 1) % stagemanager.stages.Length;
    }
}
