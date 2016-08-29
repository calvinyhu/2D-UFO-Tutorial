using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform UFOTransform;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - UFOTransform.position;
    }

    void LateUpdate()
    {
        transform.position = UFOTransform.position + offset;
    }
}
