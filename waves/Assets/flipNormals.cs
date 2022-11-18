using UnityEngine;
using System.Linq;
using System.Collections;

public class flipNormals : MonoBehaviour
{
    public bool collidersExistence = true;

    private void Start()
    {
        CreateInvertedMeshCollider();
    }
    public void CreateInvertedMeshCollider()
    {
        if (collidersExistence)
            RemoveExistingColliders();

        InvertMesh();

        gameObject.AddComponent<MeshCollider>();
        collidersExistence = true;
    }

    private void RemoveExistingColliders()
    {
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);
        collidersExistence = false;
    }

    private void InvertMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}