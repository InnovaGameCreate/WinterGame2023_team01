using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerNum : MonoBehaviour
{
    
    public GameObject num= null; // Text�I�u�W�F�N�g
    public int player_num = 0; // �ϐ�

    // Update is called once per frame
    void Update()
    {
         // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text Player_text = num.GetComponent<Text> ();
             // �e�L�X�g�̕\�������ւ���
     Player_text.text = "Player:" + player_num;

    }
}
