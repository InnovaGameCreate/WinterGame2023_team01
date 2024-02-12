using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TurnControl : MonoBehaviour
{
    [SerializeField] private ObjectMaker objectMaker;
    [SerializeField] private TextMeshProUGUI turnText;
    private GameObject data;
    private Data dataCs;
    int player;
    int player_num;
    public int winner_count;


    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        turnText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        player_num = objectMaker.player_num;
        dataCs.player_num = player_num;
        player = objectMaker.players + 1;
        dataCs.turn = player;
        winner_count = objectMaker.winner_count;
        dataCs.winner_count = winner_count;

        if (player_num == 0)
        {
            turnText.text = "Solo Mode";
        }
        else
        {
            switch (player)
            {
                case 1:
                    turnText.text = "<style=Blue>Player" + player + "</style>";
                    break;
                case 2:
                    turnText.text = "<style=Red>Player" + player + "</style>";
                    break;

                default:
                    turnText.text = "Player" + player;
                    break;

            }
        }

    }
}
