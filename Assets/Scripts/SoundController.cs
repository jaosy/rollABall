using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }

}
