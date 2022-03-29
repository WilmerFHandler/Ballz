using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Launcher : MonoBehaviour
{
    public event Action OnShoot;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject preview;

    [Range(0f, 1f)]
    [SerializeField] float timeBetweenShots;

    public LauncherInputs input;

    public int numberOfBalls = 10;
    bool isShooting;

    void Awake()
    {
        input = new LauncherInputs();
    }

    void Update()
    {
        EnableAndDisablePreview();
    }

    public void Fire(Vector2 aimDirection)
    {
        if(isShooting) return;
        if(!canShoot(aimDirection)) return;

            StartCoroutine(IShoot(aimDirection));
    }

    IEnumerator IShoot(Vector2 aimDirection)
    {
        isShooting = true;
        OnShoot?.Invoke();

        for(int i = 0; i < numberOfBalls; i++)
        {
        CreateBall(aimDirection);

        yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    void CreateBall(Vector2 aimDirection)
    {
        Quaternion zeroRotation = Quaternion.Euler(Vector3.zero);
        GameObject ball = Instantiate(ballPrefab, transform.position, zeroRotation);

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = aimDirection * 20f;
    }

    public void RoundFinished()
    {
        isShooting = false;
    }

    void EnableAndDisablePreview()
    {
        if(preview == null) return;
        if(preview.activeInHierarchy == canShoot(input.aimDirection)) return;

        preview.SetActive(canShoot(input.aimDirection));
    }

    bool canShoot(Vector2 aimDirection)
    {
        if(isShooting) return false;
        return(aimDirection != Vector2.zero);
    }

    public class LauncherInputs
    {
        [HideInInspector] public Vector2 aimDirection;
    }
}
