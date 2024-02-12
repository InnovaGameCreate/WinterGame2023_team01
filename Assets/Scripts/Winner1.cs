using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner1 : MonoBehaviour
{
    [SerializeField] private Text winnerText;
    private GameObject data;
    private Data dataCs;
    private int player_num;
    private int turn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Winner script started.");

        data = GameObject.Find("Data");
        if (data != null)
        {
            dataCs = data.GetComponent<Data>();
            if (dataCs != null)
            {
                player_num = dataCs.player_num;
                turn = dataCs.turn % (player_num + 1) + 1;
            }
            else
            {
                Debug.LogError("Data script not found on Data GameObject.");
            }
        }
        else
        {
            Debug.LogError("Data GameObject not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update() method is called.");

        if (winnerText != null)
        {
            winnerText.text = "WINNER Player" + turn.ToString();
        }
        else
        {
            Debug.LogError("UI Text (winnerText) not assigned in the inspector.");
        }
    }
}
