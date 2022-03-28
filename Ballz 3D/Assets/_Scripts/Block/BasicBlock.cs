using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : Block
{
    public override void GetHit()
    {
        hp -= 1;

        if(hp <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
