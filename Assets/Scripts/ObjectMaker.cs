using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] Tsumiki;
    [SerializeField] private GameObject[] Foods;
    [SerializeField] private GameObject[] Sonota;
    private GameObject[] objGroup;
    [SerializeField] float spawnOffset;//置かれたオブジェクトの最大値からの高さ
    [SerializeField] private float wait = 3;
    public int players; 
    public float maxY = 0;
    public float minY = 0;
    bool objectMoving = true;
    bool canMake = true;
    public int count;
    public int winner_count;
    private string targetTag = "Object";
    StageSelect stagemanager;
    PlayerNum pleyermanager;
    GameObject obj;
    private int stage_num;
    public int player_num;
    public bool game_end;
    public bool objectmake;

    private Collider colliderComponent;

    // Start is called before the first frame update
    void selectObjects()
    {
        //使用するオブジェクトの種類を決定
        switch (stage_num)
        {
            case 0:
                objGroup = Tsumiki;
                break;
            case 1:
                objGroup = Foods;
                break;
            case 2:
                objGroup = Sonota;
                break;
            default:
                objGroup = Tsumiki;
                break;

        }
    }

    void Start()
    {
        obj = GameObject.Find("StageManager");
        stagemanager = obj.GetComponent<StageSelect>();
        stage_num = stagemanager.stage_num;
        selectObjects();
        obj = GameObject.Find("playerNumManager");
        pleyermanager = obj.GetComponent<PlayerNum>();
        player_num = pleyermanager.player_num;
        SpawnObject();
        count = 0;
        winner_count = 0;
        objectmake = false;
        game_end = false;

        colliderComponent = GetComponent<Collider>();
    }

public int Player_num
    {
        get { return player_num; }
        set { player_num = value; }
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public int WinnerCount
    {
        get { return winner_count; }
        set { winner_count = value; }
    }

    public float MaxY
    {
        get { return maxY; }
        set { maxY = value; }
    }

    public bool Game_end
    {
        get { return game_end; }
        set { game_end = value; }
    }

    void SpawnObject()
    {
        canMake = true;

        maxY = FindMaxY();
        minY = FindMinY();


        if (maxY < 0)
        {
            maxY = 0;
        }

        if (minY < -1)
        {
            game_end = true;
        }

        Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);

        int random;

        if (!game_end)
        {
            random = Random.Range(0, objGroup.Length);
            GameObject fallobj = objGroup[random];
            Instantiate(fallobj, spawnPosition, fallobj.transform.rotation);
 
        }
    }

    float FindMaxY()
    {
        float maxY = float.MinValue;

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objectsWithTag)
        {
            maxY = Mathf.Max(maxY, obj.transform.position.y);
        }

        return maxY;
    }

    float FindMinY()
    {
        float minY = float.MaxValue;

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objectsWithTag)
        {
            minY = Mathf.Min(minY, obj.transform.position.y);
        }

        return minY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !objectmake)
        {
            objectmake = true;
            winner_count++;
        }

        if (objectmake && canMake)
        {
            objectmake = false;
            canMake = false;
            StartCoroutine(WaitGenerateObject());
        }

        if (!game_end)
        {
            players = count % (player_num+1);
        }
    }

    IEnumerator WaitGenerateObject()
    {

        yield return new WaitForSeconds(wait);

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        
        foreach (GameObject obj in objectsWithTag)
        {
            Rigidbody objrb = obj.GetComponent<Rigidbody>();
            objectMoving = false;

            if (objrb != null && objrb.velocity.magnitude <= 0.08f)
            {
                objectMoving = true;
                break;
            }
        }

        if (objectMoving)
        {
            SpawnObject();
            count++;
        }
        else
        {
            StartCoroutine(WaitGenerateObject());
        }
    }
}
