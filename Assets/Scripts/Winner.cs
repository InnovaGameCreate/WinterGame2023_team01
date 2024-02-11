using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Winner : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private GameObject data;
    private Data dataCs;
    public int player_num;
    private int turn;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        player_num = dataCs.player_num;
        turn = dataCs.turn % (player_num + 1) + 1;

        Debug.Log("winner" + player_num);
        if (player_num != 0)
        {
            scoreText.text = "WINNER Player" + turn.ToString();
        }
        else
        {
            scoreText.text = " ";
        }
    }
}
