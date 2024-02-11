using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TurnControl : MonoBehaviour
{
    [SerializeField] private ObjectMaker objectMaker;
    [SerializeField] private TextMeshProUGUI turnText;
    private GameObject playernummanager;
    private PlayerNum playernum;
    int player;
    int player_num;
    private int player_max_num;

    // Start is called before the first frame update
    void Start()
    {
        playernummanager = GameObject.Find("PlayerNumManager");
        playernum = playernummanager.GetComponent<PlayerNum>();
        player_num = playernum.player_num;
        //data = GameObject.Find("Data");
        //dataCs = data.GetComponent<Data>();
        turnText = this.GetComponent<TextMeshProUGUI>();
    }
    void dispPlayerNum(int num)
    {
        switch (num)
        {
            case 1:
                turnText.text = "<style=Blue>player" + num + "</style>";
                break;
            case 2:
                turnText.text = "<style=Red>player" + num + "</style>";
                break;
            default:
                turnText.text = "player" + num;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player_max_num == 1) turnText.text = "";
        else if (player_max_num == 2) dispPlayerNum(player_num);
        else turnText.text = "ÉGÉâÅ[";
    }
}
