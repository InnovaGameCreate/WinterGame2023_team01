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

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        score = dataCs.score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "スコア：" + score.ToString();
    }
}
