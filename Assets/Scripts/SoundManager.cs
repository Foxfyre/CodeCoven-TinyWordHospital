using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] mySounds;

    private AudioSource cheer;
    // Start is called before the first frame update
    void Start()
    {
        mySounds = GetComponents<AudioSource>();

        cheer = mySounds[0];
    }

    public void PlayCheer()
    {
        cheer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
