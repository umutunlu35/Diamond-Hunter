using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] song;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("gameMusic");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        gameObject.GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(this.gameObject);
    }
}
