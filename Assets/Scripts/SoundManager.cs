using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] mySounds;

    private AudioSource siren;
    // Start is called before the first frame update
    void Start()
    {
        mySounds = GetComponents<AudioSource>();

        siren = mySounds[0];
    }

    public void PlaySiren()
    {
        siren.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
