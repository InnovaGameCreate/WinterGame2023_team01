using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField] public GameObject stageselect; // Text�I�u�W�F�N�g
    public int stage_num; // �ϐ�
    [SerializeField] public string[] stages;

    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text Stage_text = stageselect.GetComponent<Text>();
        // �e�L�X�g�̕\�������ւ���
        Stage_text.text = stages[stage_num];

    }
}
