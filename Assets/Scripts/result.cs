using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class result : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private GameObject data;
    private Data dataCs;
    private float score;
    private int turn;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        score = dataCs.score;
        turn = dataCs.turn % 2 + 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "�X�R�A�F" + score.ToString();

        scoreText.text = "WINNER Player" + turn.ToString();
    }
}
