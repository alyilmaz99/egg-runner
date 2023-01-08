using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Distance Settings")]
    public GameObject egg;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - egg.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = egg.transform.position + offset;
    }
}
