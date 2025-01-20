using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGmusic : MonoBehaviour
{
    // https://www.youtube.com/watch?v=ha6U8jHl9ak
    
    public static BGmusic instance;
    
    void Awake()
    {
        if (instance != null)
        {
            // if music is different than it should be (i.e. changed levels) it swaps for the new one
            if (instance.gameObject.GetComponent<AudioSource>().clip != gameObject.GetComponent<AudioSource>().clip)
            {
                instance.gameObject.GetComponent<AudioSource>().clip = gameObject.GetComponent<AudioSource>().clip;
                instance.gameObject.GetComponent<AudioSource>().Play();
            }
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("instance");
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
}