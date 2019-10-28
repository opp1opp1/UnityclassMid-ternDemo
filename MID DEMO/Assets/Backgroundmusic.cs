using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmusic : MonoBehaviour {
    private AudioSource bgMusicAudioSource;
    private bool activate = false;
    private GameObject target;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Boss");
	}
    private void OnEnable()
    {
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update () {
        if (target.GetComponent<BossBehavior>().Health <= 100&& activate !=true)
        {
            bgMusicAudioSource.volume = 1f;
            bgMusicAudioSource.pitch = 1f;
            activate = true;
        }
	}
}
