using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numM1 : MonoBehaviour
{
    public void OnClick()
    {
        PlayerNum playernum;
         GameObject obj = GameObject.Find("playerNumManager"); 
           playernum = obj.GetComponent<PlayerNum>(); //付いているスクリプトを取得
        // ボタンが押されたら人数を一つ増す
     
        playernum.player_num -= 1;
        if(   playernum.player_num <= 1){
           playernum.player_num = 1;
        }
    }
}
