using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase : MonoBehaviour
{
    GameObject obj;
    PlayerNum playernum;
    private int maxNum;

    private void Start()
    {
        obj = GameObject.Find("playerNumManager");
        playernum = obj.GetComponent<PlayerNum>(); //�t���Ă���X�N���v�g���擾
        maxNum = playernum.player_max_num;

    }
    public void OnClick()
    {
        playernum.player_num %= maxNum;
        playernum.player_num++;
    }
}
