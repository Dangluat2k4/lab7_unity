using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
        public AudioSource vfxAudioScource;
        public AudioClip soundStack;
    // Start is called before the first frame update
    void Start()
    {
     musicAudioSource.clip = soundStack;
     musicAudioSource.Play();   
    }

    // Update is called once per frame
    void Update()
    {
        if(!musicAudioSource.isPlaying){
            musicAudioSource.Play();
        }
    }
}
