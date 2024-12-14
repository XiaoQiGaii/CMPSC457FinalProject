using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SineWaveGenerator : MonoBehaviour
{
    public int resolution = 150;
    public float xRange = 10f;
    public float amplitude = 1f; 

    private LineRenderer lineRenderer;

    void Start()
    {
       
        lineRenderer = GetComponent<LineRenderer>();

       
        lineRenderer.positionCount = resolution;

        
        GenerateSineWave();
    }

    void GenerateSineWave()
    {
        Vector3[] positions = new Vector3[resolution];

        for (int i = 0; i < resolution; i++)
        {
            
            float x = (i / (float)(resolution - 1)) * xRange;

            
            float y = Mathf.Sin(x) * amplitude;

            
            positions[i] = new Vector3(x, y, 0);
        }


        lineRenderer.SetPositions(positions);


        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.red;
    }
}
