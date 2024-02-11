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

    }
}
