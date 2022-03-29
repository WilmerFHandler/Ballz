using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    [SerializeField] float previewLength;
    List<GameObject> previewBalls;
    public PreviewInput input;

    void Awake()
    {
        previewBalls = GetChildrenAsGameObjects();
        input = new PreviewInput();
    }

    void Update()
    {
        UpdatePreview();
    }

    List<GameObject> GetChildrenAsGameObjects()
    {
        List<GameObject> children = new List<GameObject>();

        for(int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        return children;
    }

    public void UpdatePreview()
    {
        UpdatePreviewPositions();
    }

    Vector3 GetTargetEndPoint()
    {
        Vector3 direction = new Vector3(input.aimDirection.x, input.aimDirection.y, 0f);
        Vector3 targetEndPoint = transform.position + direction * previewLength;

        return targetEndPoint;
    }

    void UpdatePreviewPositions()
    {
        for(int i = 0; i < previewBalls.Count; i++)
        {
            GameObject previewBall = previewBalls[i];
            float fractionOfDistance = (i + 1) / IntToFloat(previewBalls.Count);

            Vector3 position = Vector3.Lerp(transform.position, GetTargetEndPoint(), fractionOfDistance);

            previewBall.transform.position = position;
        }
    }

    float IntToFloat(int a)
    {
        float b = a;

        return b;
    }
}

    public class PreviewInput
    {
        [HideInInspector] public Vector2 aimDirection;
    }
