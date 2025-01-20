using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    public Vector3 endPos;
    private Vector3 center;
    private Vector3 direction;

    void Start()
    {
        startPos = transform.position;
        center = startPos + ((endPos - startPos) / 2f);
        direction = (endPos - startPos) / 2f;
    }
    
    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp (startPos, endPos, Mathf.PingPong((Mathf.Sin(Time.time) + 0.5f) * speed, 1.0f));
        transform.position = center + direction * (Mathf.Sin(Time.time * speed));
    }
}
