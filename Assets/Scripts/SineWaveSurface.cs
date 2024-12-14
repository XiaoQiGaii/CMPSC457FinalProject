using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SineWaveSurface : MonoBehaviour
{
    public int xSegments = 50; // x ����ϸ����
    public int zSegments = 50; // z ����ϸ����
    public float xRange = 5f;  // x �ķ�Χ
    public float zRange = 5f;  // z �ķ�Χ
    public float amplitude = 1f; // ���
    public float frequency = 1f; // ����Ƶ��
    public float speed = 1f;     // �����ٶ�

    private Mesh mesh;

    void Start()
    {
        GenerateSurface();
    }

    void Update()
    {
        AnimateSurface();
    }

    void GenerateSurface()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // ������
        Vector3[] vertices = new Vector3[(xSegments + 1) * (zSegments + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[xSegments * zSegments * 6];

        // ��������� UV
        for (int z = 0; z <= zSegments; z++)
        {
            for (int x = 0; x <= xSegments; x++)
            {
                float xPos = (x / (float)xSegments) * xRange;
                float zPos = (z / (float)zSegments) * zRange;

                int index = z * (xSegments + 1) + x;
                vertices[index] = new Vector3(xPos, 0, zPos); // ��ʼ�߶�Ϊ 0
                uv[index] = new Vector2(x / (float)xSegments, z / (float)zSegments);
            }
        }

        // ��������������
        int t = 0;
        for (int z = 0; z < zSegments; z++)
        {
            for (int x = 0; x < xSegments; x++)
            {
                int i = z * (xSegments + 1) + x;
                triangles[t++] = i;
                triangles[t++] = i + xSegments + 1;
                triangles[t++] = i + 1;

                triangles[t++] = i + 1;
                triangles[t++] = i + xSegments + 1;
                triangles[t++] = i + xSegments + 2;
            }
        }

        // Ӧ�õ� Mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void AnimateSurface()
    {
        Vector3[] vertices = mesh.vertices;

        for (int z = 0; z <= zSegments; z++)
        {
            for (int x = 0; x <= xSegments; x++)
            {
                int index = z * (xSegments + 1) + x;
                Vector3 vertex = vertices[index];
                vertex.y = Mathf.Sin(Time.time * speed + vertex.x * frequency) * Mathf.Sin(Time.time * speed + vertex.z * frequency) * amplitude;
                vertices[index] = vertex;
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals(); // ���¼��㷨�����ڹ���
    }
}
