using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    // Start is called before the first frame update

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }


    public void effectToPlay(int effectToPlay)
    {
        soundEffects[effectToPlay].Stop();
        soundEffects[effectToPlay].Play();
    }
}
