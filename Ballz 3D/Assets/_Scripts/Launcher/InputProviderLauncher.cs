using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class FireEvent : UnityEvent<Vector2> {}
public class InputProviderLauncher : MonoBehaviour
{
    MainControls controls;

    public FireEvent OnFire;

    Vector2 aimDirection;
    Vector2 startMousePosition;
    bool isAiming;

    void OnEnable()
    {
        if(controls == null)
        {
            controls = new MainControls();
        }
        controls.Enable();

        controls.Gameplay.Fire.performed += ctx => OnFire?.Invoke(aimDirection);
        controls.Gameplay.Aiming.started += ctx => StartAiming();
        controls.Gameplay.Aiming.canceled += ctx => isAiming = false;
    }
    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        UpdateAimingDirection();
    }

    void UpdateAimingDirection()
    {
        if(isAiming)
        {
            Vector2 mousePosition = controls.Gameplay.Aim.ReadValue<Vector2>();
            aimDirection = (startMousePosition - mousePosition).normalized;
        } else
        {
            aimDirection = Vector2.zero;
        }
    }

    void StartAiming()
    {
        isAiming = true;

        startMousePosition = controls.Gameplay.Aim.ReadValue<Vector2>();
    }
}
