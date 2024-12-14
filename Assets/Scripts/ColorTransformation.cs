using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransformation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float scaleSpeed = 2f;
    public float minScale = 0.5f;
    public float maxScale = 2f;
    private bool isScalingUp = true;

    public Material material;

    // Update is called once per frame
    void Update()
    {
        Transformation();

        ChangeColor();
    }

    private void Transformation()
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

    private void ChangeColor()
    {
        float r = Mathf.Sin(Time.time) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time + 4f) * 0.5f + 0.5f;

        material.color = new Color(r, g, b);
    }
}
