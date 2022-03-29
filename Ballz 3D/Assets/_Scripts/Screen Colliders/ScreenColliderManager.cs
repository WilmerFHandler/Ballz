using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColliderManager : MonoBehaviour
{
    [SerializeField] GameObject top, left, right, bottom;
    [SerializeField] PhysicsMaterial2D physicsMaterial;
    float _colliderWidth = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CreateScreenColliders();
    }

    void CreateScreenColliders()
    {
        Camera cam = Camera.main;
        Vector3 bottomLeftScreenPoint = cam.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRightScreenPoint = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -cam.transform.position.z));
        Vector3 centerScreenPoint = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, -cam.transform.position.z));

        CreateTopCollider(bottomLeftScreenPoint, topRightScreenPoint, centerScreenPoint);
        CreateLeftCollider(bottomLeftScreenPoint, topRightScreenPoint, centerScreenPoint);
        CreateRightCollider(bottomLeftScreenPoint, topRightScreenPoint, centerScreenPoint);
        CreateBottomCollider(bottomLeftScreenPoint, topRightScreenPoint, centerScreenPoint);
    }

    void CreateTopCollider(Vector3 bottomLeftScreenPoint, Vector3 topRightScreenPoint, Vector3 centerScreenPoint)
    {
        Vector2 size = new Vector2(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), _colliderWidth);
        Vector3 position = new Vector3(centerScreenPoint.x, topRightScreenPoint.y + _colliderWidth / 2f, 0f);

        top.transform.position = position;
        BoxCollider2D collider = top.AddComponent<BoxCollider2D>();
        collider.size = size;
        collider.sharedMaterial = physicsMaterial;
    }
    void CreateLeftCollider(Vector3 bottomLeftScreenPoint, Vector3 topRightScreenPoint, Vector3 centerScreenPoint)
    {
        Vector2 size = new Vector2(_colliderWidth, Mathf.Abs(bottomLeftScreenPoint.y - topRightScreenPoint.y));
        Vector3 position = new Vector3(bottomLeftScreenPoint.x - _colliderWidth / 2f, centerScreenPoint.y, 0f);

        left.transform.position = position;
        BoxCollider2D collider = left.AddComponent<BoxCollider2D>();
        collider.size = size;
        collider.sharedMaterial = physicsMaterial;
    }
    void CreateRightCollider(Vector3 bottomLeftScreenPoint, Vector3 topRightScreenPoint, Vector3 centerScreenPoint)
    {
        Vector2 size = new Vector2(_colliderWidth, Mathf.Abs(bottomLeftScreenPoint.y - topRightScreenPoint.y));
        Vector3 position = new Vector3(topRightScreenPoint.x + _colliderWidth / 2f, centerScreenPoint.y, 0f);

        right.transform.position = position;
        BoxCollider2D collider = right.AddComponent<BoxCollider2D>();
        collider.size = size;
        collider.sharedMaterial = physicsMaterial;
    }
    void CreateBottomCollider(Vector3 bottomLeftScreenPoint, Vector3 topRightScreenPoint, Vector3 centerScreenPoint)
    {
        Vector2 size = new Vector2(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), _colliderWidth);
        Vector3 position = new Vector3(centerScreenPoint.x, bottomLeftScreenPoint.y - _colliderWidth / 2f, 0f);

        bottom.transform.position = position;
        BoxCollider2D collider = bottom.AddComponent<BoxCollider2D>();
        collider.size = size;

        collider.isTrigger = true;
    }
}
