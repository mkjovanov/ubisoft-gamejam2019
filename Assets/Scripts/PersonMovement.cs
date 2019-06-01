using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PersonMovement : MonoBehaviour
{
    public Transform target;

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    public Vector3 gotoDestination;

    public int areaMask;
    NavMeshPath path;
    Vector3[] results;
    public NavMeshQueryFilter filter;

    public void GoTo(Vector3 pos)
    {
        gotoDestination = pos;
    }

    private void Start()
    {
        filter = new NavMeshQueryFilter();
        filter.areaMask = 1;
        results = new Vector3[2];
        path = new NavMeshPath();

        if (target)
            GoTo(target.position);
    }

    void Update()
    {
        if (NavMesh.CalculatePath(transform.position, gotoDestination, filter, path))
        {
            path.GetCornersNonAlloc(results);

            Vector3 diff = results[1] - transform.position;
            diff.y = Mathf.Clamp(diff.y, 0, Mathf.Infinity);

            rb.AddForce(diff.normalized * 10);

            Debug.DrawRay(results[1], Vector3.up, Color.red);
        }
    }
}
