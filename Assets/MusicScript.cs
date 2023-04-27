using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic()
    {
        if (source.isPlaying) return;
        source.Play();
    }

    public void StopMusic()
    {
        source.Stop();
    }
}
