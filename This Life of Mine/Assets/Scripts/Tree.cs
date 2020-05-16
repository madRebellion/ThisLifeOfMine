using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MeshRenderer trunkMeshRenderer, leavesMeshRenderer;
    public Material barkMaterial;
    public Material[] leavesMaterial;

    // Start is called before the first frame update
    void Start()
    {
        trunkMeshRenderer.sharedMaterial = barkMaterial;

        RandomiseProperties();
    }

    void RandomiseProperties()
    {
        RandomiseLeavesColour();
        RandomiseTransform();
    }

    void RandomiseLeavesColour()
    {
        int leaves = Random.Range(0, 3);

        leavesMeshRenderer.sharedMaterial = leavesMaterial[leaves];
    }

    void RandomiseTransform()
    {
        Vector3 rot = new Vector3(transform.rotation.x, Random.Range(0, 359), transform.rotation.z);
        transform.eulerAngles = rot;

        Vector3 scale = new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f));
        transform.localScale = scale;
    }
}
