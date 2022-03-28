using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] Launcher launcher;
    int _numberOfBallsLeft;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.TryGetComponent<Ball>(out Ball ball))
        {
            BallEnter(ball);
        }
    }

    void BallEnter(Ball ball)
    {
        _numberOfBallsLeft -= 1;

        if(_numberOfBallsLeft <= 0)
        {
            launcher.RoundFinished();
        }

        Destroy(ball.gameObject);
    }

    void RoundStart()
    {
        _numberOfBallsLeft = launcher.numberOfBalls;
    }

    void OnEnable()
    {
        launcher.OnShoot += RoundStart;
    }
}
