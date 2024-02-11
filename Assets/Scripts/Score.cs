using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private ObjectMaker objectMaker;
    [SerializeField] private float weight1;
    [SerializeField] private float weight2;
    [SerializeField] private Text scoreText;
    [SerializeField] int countValue;
    [SerializeField] float yValue;
    private GameObject data;
    private Data dataCs;
    bool end;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {

        countValue = objectMaker.Count;
        yValue = objectMaker.MaxY;
        end = objectMaker.game_end;
        //score = countValue;
        //score = yValue;
        if (!end) {
            score = (float)countValue * weight1 + yValue * weight2;
            score = (int)Math.Floor(score);
            dataCs.score = score;
        }

        scoreText.text = "スコア：" + score.ToString();
    }
}
