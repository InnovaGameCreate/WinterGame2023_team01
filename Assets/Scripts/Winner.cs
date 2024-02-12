using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Winner : MonoBehaviour
{
    [SerializeField] private Text winnerText;
    private GameObject data;
    private Data dataCs;
    private int player_num;
    private int winner;
    private int winner1;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        player_num = dataCs.player_num;
        winner = dataCs.winner_count;
        winner1 = dataCs.winner_count1 % 2;
        winner = ((winner + winner1) % (player_num+1)) +1;

    }

    // Update is called once per frame
    void Update()
    {
        if(player_num == 0)
        {
            winnerText.text = " ";
        }
        else
        {
            winnerText.text = "WINNER Player" + winner.ToString();
        }
    }
}
