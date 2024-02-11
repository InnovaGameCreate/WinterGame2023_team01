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

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        dataCs.turn = player;
        player = objectMaker.players + 1;
        turnText.text = "Player" + player.ToString();
    }
}
