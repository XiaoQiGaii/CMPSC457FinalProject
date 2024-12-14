using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float scaleSpeed = 2f;
    public float minScale = 0.5f;
    public float maxScale = 2f;
    private bool isScalingUp = true;

    // Update is called once per frame
    void Update()
    {
        Transforming();
    }

    private void Transforming()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);


        if (isScalingUp)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x >= maxScale)
            {
                isScalingUp = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x <= minScale)
            {
                isScalingUp = true;
            }
        }
    }
}
