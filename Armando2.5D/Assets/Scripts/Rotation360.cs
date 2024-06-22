using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation360 : MonoBehaviour
{
    public Vector3 axisRotate;
    public float speed;

    void Update()
    {
        transform.Rotate(axisRotate * speed * Time.deltaTime);
    }
}
