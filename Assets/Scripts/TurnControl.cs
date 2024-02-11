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
        dataCs.turn = player;
        player = objectMaker.players + 1;
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
