using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCenterController : MonoBehaviour
{
    public float gravityMultiplier = 50f;
    public float maxRange = 3f;
    private bool clickingOutsideRange = false;
    private PlayerController player;
    private Transform maxRangeSprite;
    private AudioSource audio;
    public SpriteRenderer highlight; // sprite
    [SerializeField] private AudioClip highlightClip;
    [SerializeField] private AudioClip highlightOffClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip clickOffClip;
    //private CircleCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        maxRangeSprite = transform.Find("MaxRangeCircle");
        audio = GetComponentInChildren<AudioSource>();
        //collider = GetComponent<CircleCollider2D>();
        highlight.color = Color.white;
        
        maxRangeSprite.localScale = 2 * maxRange * Vector3.one;
        //collider.radius = maxRange * 2f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OrbitThis()
    {
        player.OrbitObject(this);
    }

    private void OnMouseDown()
    {
        // if less than max distance
        if ((transform.position - player.transform.position).magnitude < maxRange)
        {
            OrbitThis();
            audio.PlayOneShot(clickClip);
        }
        else
        {
            clickingOutsideRange = true;
        }
    }

    private void OnMouseDrag()
    {
        // if in range holding click (to allow buffering an orbit)
        if (clickingOutsideRange && (transform.position - player.transform.position).magnitude < maxRange)
        {
            OrbitThis();
            //audio.PlayOneShot(clickClip); // SPAMS SOUND, DONT USE UNTIL FIXED!!
        }
    }

    private void OnMouseEnter()
    {
        highlight.color = Color.red;
        audio.PlayOneShot(highlightClip);
    }

    private void OnMouseExit()
    {
        highlight.color = Color.white;
        if (!clickingOutsideRange)
        {
            audio.PlayOneShot(highlightOffClip);
        }
    }

    private void OnMouseUp()
    {
        clickingOutsideRange = false;
        audio.PlayOneShot(clickOffClip);
    }
}
