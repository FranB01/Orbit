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
    private PlayerController player;

    void Start()
    {
        sprite  = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<PlayerController>();
        Blink();
    }

    public void Blink()
    {
        blinking = true;
        StartCoroutine(BlinkAndWait());
    }

    private IEnumerator BlinkAndWait()
    {
        int blinkRepeat = 3;
        for (int i = 0; i < blinkRepeat; i++)
        {
            yield return StartCoroutine(BlinkCoroutine());
        }
        player.moving = true;
    }

    private IEnumerator BlinkCoroutine()
    {
        audioSource.PlayOneShot(sound);
        sprite.enabled = true;
        yield return new WaitForSeconds(blinkTimeOn);
        sprite.enabled = false;
        yield return new WaitForSeconds(blinkTimeOff);
    }

    
}
