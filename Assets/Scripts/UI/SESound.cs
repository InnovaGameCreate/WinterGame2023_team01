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
    //ボタンをクリックした時のスクリプトです。
    public void OnClick()
    {
        sound.PlayOneShot(sound.clip);
    }
}
