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
    private int turn;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        player_num = dataCs.player_num;
        turn = dataCs.turn % (player_num + 1) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ");
    
        winnerText.text = "WINNER Player" + turn.ToString();
      
    }
}
