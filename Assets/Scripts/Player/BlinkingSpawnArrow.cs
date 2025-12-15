using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSpawnArrow : MonoBehaviour
{
    private float blinkTimeOn = .15f;
    private float blinkTimeOff = .10f;
    private int blinkRepeat = 3;
    //private int blinkCount = 0;
    private bool blinking = false;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite  = GetComponent<SpriteRenderer>();
        Blink();
    }

    public void Blink()
    {
        blinking = true;
        Time.timeScale = 0;
        StartCoroutine(BlinkAndWait());
    }

    private IEnumerator BlinkAndWait()
    {
        int blinkRepeat = 3;
        for (int i = 0; i < blinkRepeat; i++)
        {
            yield return StartCoroutine(BlinkCoroutine());
        }
        Time.timeScale = 1;
    }

    private IEnumerator BlinkCoroutine()
    {
        audioSource.PlayOneShot(sound);
        sprite.enabled = true;
        yield return new WaitForSecondsRealtime(blinkTimeOn);
        sprite.enabled = false;
        yield return new WaitForSecondsRealtime(blinkTimeOff);
    }

    
}
