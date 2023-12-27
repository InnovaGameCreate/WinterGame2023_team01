using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] float spawnOffset;
    [SerializeField] private float wait;
    [SerializeField] private string targetTag = "Object";
    bool objectMooving = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        float maxY = FindMaxY();
        Debug.Log(maxY);

        if(maxY < 0)
        {
            maxY = 0;
        }

        Vector3 spawnPosition = new Vector3(0, maxY + spawnOffset, 0);

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
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

    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);
        objectMooving = false;

        foreach (GameObject obj in objectsWithTag)
        {
            Rigidbody objrb = obj.GetComponent<Rigidbody>();
            if (objrb != null && objrb.velocity.magnitude >= 0.1f)
            {
                objectMooving = true;
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)�@&& !objectMooving)
        {    
            StartCoroutine(WaitGenerateObject());
        }
    }

    IEnumerator WaitGenerateObject()
    {
        yield return new WaitForSeconds(wait);

        Debug.Log("�V�����I�u�W�F�N�g�����������");
        SpawnObject();
    }

    //�v���O�����̖��_�FEnter��A�ł���ƃI�u�W�F�N�g����ʂɐ��������
    //�����FEnter����͂������_�ł̔���ɂȂ邽�߁C�ݒu���Ă��Ȃ��I�u�W�F�N�g�������Ԃł��I�u�W�F�N�g�����������
    //�����āFEnter�̓��͂��t���O�ɂ��Ă��̃t���O�̏�ԂŃI�u�W�F�N�g�𐶐�����
}
