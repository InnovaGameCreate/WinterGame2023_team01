using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    
    public GameObject num = null; // Text�I�u�W�F�N�g
    [SerializeField] public int player_max_num;
    public int player_num = 0; // �ϐ�
    [SerializeField] string playerText;
    private TextMeshProUGUI Player_text;

    // Update is called once per frame
    private void Start()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Player_text = num.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
       
        // �e�L�X�g�̕\�������ւ���
        Player_text.text = playerText + "�F" + player_num;

    }
}
