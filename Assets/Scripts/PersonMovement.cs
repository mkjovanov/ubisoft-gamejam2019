using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PersonMovement : MonoBehaviour
{
    public Transform target;

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    public float forceMult = 10;

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

    public bool grounded;

    public LayerMask raycastLayermask;

    void Update()
    {
        Vector3 groundNormal = Vector3.up;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.51f, -transform.up, out hit, 1.1f, raycastLayermask))
        {
            groundNormal = hit.normal;
            grounded = true;
            rb.drag = 4;
        }
        else
        {
            grounded = false;
            rb.drag = 1;
        }

        if (NavMesh.CalculatePath(transform.position, gotoDestination, filter, path))
        {
            path.GetCornersNonAlloc(results);

            Vector3 diff = results[1] - transform.position;
            diff.y = Mathf.Clamp(diff.y, 0, Mathf.Infinity);
            if (diff.magnitude < 0.1f) diff = diff.normalized * 0.1f;
            else
                diff = Vector3.ClampMagnitude(diff, 1);

            diff = Vector3.ProjectOnPlane(diff, groundNormal);

            Debug.DrawRay(hit.point, diff, Color.blue);

            if (grounded)
                rb.AddForce(diff * forceMult);

            Debug.DrawRay(results[1], Vector3.up, Color.red);
        }



        //Debug.Log(grounded);
    }
}
