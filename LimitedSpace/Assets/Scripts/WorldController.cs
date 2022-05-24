using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Transform GetCameraTransform()
    {
        return _cameraTransform;
    }

    [SerializeField] private Transform _cameraTransform;
}
