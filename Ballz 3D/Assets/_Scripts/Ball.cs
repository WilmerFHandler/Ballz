using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        Block block = collider.transform.GetComponent<Block>();
        if(block)
        {
            block.GetHit();
        }
    }
}
