using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESound : MonoBehaviour
{
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    //�{�^�����N���b�N�������̃X�N���v�g�ł��B
    public void OnClick()
    {
        sound.PlayOneShot(sound.clip);
    }
}
