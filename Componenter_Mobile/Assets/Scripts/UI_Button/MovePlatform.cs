 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlatform : MonoBehaviour
{
    public float time;
    public Vector2 speed;
    [SerializeField] float pretime;
    public Rigidbody2D rigidbody;

    private void Awake()
    {
        pretime = time;
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = speed;
        pretime -= Time.deltaTime;
        if (pretime < 0)
        {
            pretime = time;
            speed = -speed;
        }
    }
}
