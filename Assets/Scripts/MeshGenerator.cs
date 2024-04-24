using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public int sides = 6;
    public float radius = 1f;
    public Material polygonMaterial;

    private void Start()
    {
        GeneratePolygon();
    }

    private void GeneratePolygon()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // Create vertices for the polygon
        Vector3[] vertices = new Vector3[sides];
        for (int i = 0; i < sides; i++)
        {
            float angle = 2 * Mathf.PI * i / sides;
            vertices[i] = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);
        }

        // Create triangles to form the polygon
        int[] triangles = new int[3 * (sides - 2)];
        for (int i = 0; i < sides - 2; i++)
        {
            triangles[3 * i] = 0;
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }

        // Create the mesh
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Assign the material
        meshRenderer.material = polygonMaterial;

        // Set the mesh
        meshFilter.mesh = mesh;
    }
}
