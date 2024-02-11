using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnControl : MonoBehaviour
{
    [SerializeField] private ObjectMaker objectMaker;
    [SerializeField] private Text turnText;
    private GameObject data;
    private Data dataCs;
    int player;
    int player_num;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {

        player_num = objectMaker.player_num;
        dataCs.player_num = player_num;
        player = objectMaker.players + 1;
        dataCs.turn = player;

        Debug.Log(player_num);
        if(player_num == 0)
        {
            turnText.text = "Solo Mode";
        }
        else
        {
            turnText.text = "Player" + player.ToString();
        }
    }
}
