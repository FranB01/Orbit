using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private bool orbiting = false;
    private float speed = 5.0f;
    private int orbitingDirection;
    private bool dead = false;
    private bool winning = false;

    private Vector2 positionBeforeWinning;

    public Transform orbitingObject;
    private GameControl gc;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource audio;
    private ParticleSystem particle;
    private Transform goal;

    [SerializeField] private AudioClip[] explodeClips;
    [SerializeField] private AudioClip outOfBoundsClip;
    [SerializeField] private AudioClip winClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameControl>();
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponentInChildren<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            orbiting = false;
        }

        if (Input.GetButtonDown("Restart"))
        {
            gc.RestartLevel();
        }

        if (winning && transform.localScale.x > 0f)
        {
            transform.position = Vector2.Lerp(positionBeforeWinning, goal.position, 10f);
            sr.transform.localScale -= Vector3.one * (0.2f * Time.deltaTime);
        }

        // POSSIBLE MOVEMENT OPTION, RCLICK TO INVERT DIRECTION
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            orbitingDirection = -orbitingDirection;
            transform.Rotate(Vector3.forward, 180);
        }
        */
    }

    void FixedUpdate()
    {
        if (!dead && !winning)
        {
            if (orbiting)
            {
                // angular velocity = velocity / radius
                float angularSpeed = speed * Time.deltaTime * Mathf.Rad2Deg /
                                     Vector3.Distance(transform.position, orbitingObject.position);
                transform.RotateAround(orbitingObject.position, orbitingDirection * Vector3.forward, angularSpeed);
                //transform.Rotate(Vector3.up, angularSpeed);
                //Debug.Log(angularSpeed);
            }
            else
            {
                transform.Translate(Vector3.right * (speed * Time.deltaTime));
            }
        }
    }

    public void OrbitObject(GravityCenterController newOrbitingObject)
    {
        orbitingObject = newOrbitingObject.transform;
        // check which side it's on to determine rotation direction
        Debug.Log(transform.InverseTransformPoint(newOrbitingObject.transform.position).y);
        if (transform.InverseTransformPoint(newOrbitingObject.transform.position).y < 0)
        {
            orbitingDirection = -1;
        }
        else
        {
            orbitingDirection = 1;
        }

        transform.up = (orbitingObject.position - transform.position) * orbitingDirection;
        //transform.Rotate(Vector3.forward, Vector2.Angle(new Vector2(orbitingObject.position.x, orbitingObject.position.y), new Vector2(transform.position.x ,transform.position.y)));
        //transform.Rotate(0,0,orbitingDirection * 90);

        orbiting = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillOnTouch"))
        {
            Debug.Log("Kill :(");
            Explode();
        }
        else if (other.gameObject.CompareTag("OutOfBounds"))
        {
            OutOfBounds();
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal :D");
            goal = other.transform;
            Win();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin :)");
            CoinControl coin = other.gameObject.GetComponent<CoinControl>();
            coin.GetCoin();
        } else if (other.gameObject.CompareTag("BouncyBlock"))
        {
            BouncyBlock bouncyBlock = other.gameObject.GetComponent<BouncyBlock>();
            bouncyBlock.Bounce();
            Bounce(bouncyBlock.vertical);
        }
    }

    // if true bounces on the y axis, otherwise x
    private void Bounce(bool vertical)
    {
        Debug.Log("Bouncing... Vertical: " + vertical);
        // rotates on a given axis given euler angles
        if (vertical)
        {
            transform.Rotate((-2 * transform.rotation.eulerAngles.z) * Vector3.forward);
        }
        else
        {
            transform.Rotate((-2 * (transform.rotation.eulerAngles.z + 90)) * Vector3.forward);
        }
    }

    private void OutOfBounds()
    {
        audio.PlayOneShot(outOfBoundsClip);
        Die();
    }

    private void Explode()
    {
        // camera shake
        if (PlayerPrefs.GetInt("ScreenShake") == 1)
        {
            FindObjectOfType<CameraShake>().shakeDuration = 0.05f;
        }
        audio.PlayOneShot(explodeClips[Random.Range(0, explodeClips.Length)]);
        particle.Play();
        Die();
    }

    private void Die()
    {
        dead = true;
        sr.enabled = false;
        StartCoroutine(gc.GameOver());
    }

    private void Win()
    {
        // todo
        positionBeforeWinning = transform.position;
        winning = true;
        audio.PlayOneShot(winClip);
        StartCoroutine(gc.Win());
    }
}