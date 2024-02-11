using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    
    public GameObject num = null; // Text�I�u�W�F�N�g
    [SerializeField] private string[] playerNumStr;
    public int player_max_num;
    public int player_num; // �ϐ�
    [SerializeField] string playerText;
    private TextMeshProUGUI Player_text;

    // Update is called once per frame
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Title") DontDestroyOnLoad(this);
        player_num = 0;//������
        player_max_num = playerNumStr.Length;
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Player_text = num.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
       
        // �e�L�X�g�̕\�������ւ���
        Player_text.text = playerText + "�F" + playerNumStr[player_num];

    }
}
