using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class AITest : MonoBehaviour
{
    void Start()
    {
        path = new NavMeshPath();
        filter.areaMask = areaMask;
    }

    public Transform target;

    NavMeshPath path;

    public int areaMask;
    Vector3[] results = new Vector3[2];

    public NavMeshQueryFilter filter;

    void Update()
    {
        if (NavMesh.CalculatePath(transform.position, target.position, filter, path))
        {
            //Debug.Log("Found!");
            path.GetCornersNonAlloc(results);

            Debug.DrawRay(results[1], Vector3.up, Color.red);

            /*
            foreach (var result in results)
            {
                Debug.DrawRay(result, Vector3.up, Color.red);
            }*/
        }
    }
}
