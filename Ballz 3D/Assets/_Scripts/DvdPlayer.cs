using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvdPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
    }
}
