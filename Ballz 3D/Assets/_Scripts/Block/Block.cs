using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] protected int hp;
    public abstract void GetHit();
    protected virtual void Die()
    {
        return;
    }
}
