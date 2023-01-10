using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
     [SerializeField] float rotateSpeed = 60f;

    [SerializeField] private int startAngle ;
    [SerializeField] private int offset ;
    [SerializeField] private bool direction;
    [SerializeField] private int directionDegree;
    void Start()
    {
        if (direction)
        {
            directionDegree = 0;
        }
        else
        {
            directionDegree = 180;
        }
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, directionDegree, Mathf.PingPong(Time.time * rotateSpeed, offset) - startAngle);
    }
}
