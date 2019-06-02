using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PersonMovement : MonoBehaviour
{
    public Transform[] targets;
    private int currentTargetIndex;

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    public float forceMult = 10;

    public Vector3 gotoDestination;

    public int areaMask;
    NavMeshPath path;
    Vector3[] results;
    public NavMeshQueryFilter filter;

    public Transform leftArm;
    public Transform rightArm;

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

        if (targets != null && targets.Length > 0)
        {
            GoTo(targets[0].position);
            currentTargetIndex = 0;
        }
    }

    public bool grounded;

    public LayerMask raycastLayermask;

    float groundVelocity;
    float groundTrack;

    Vector2 lastGroundPos;

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

        Vector2 groundPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 groundDiff = lastGroundPos - groundPos;
        lastGroundPos = groundPos;
        float groundVelocity = groundDiff.magnitude;
        groundTrack += groundVelocity;

        if (NavMesh.CalculatePath(transform.position, gotoDestination, filter, path))
        {
            path.GetCornersNonAlloc(results);

            Vector3 diff = results[1] - transform.position;
            diff.y = Mathf.Clamp(diff.y, 0, Mathf.Infinity);
            groundVelocity = diff.magnitude;
            if (diff.magnitude < 0.1f) diff = diff.normalized * 0.1f;
            else
                diff = Vector3.ClampMagnitude(diff, 1);

            diff = Vector3.ProjectOnPlane(diff, groundNormal);

            Vector3 rotDir = diff;
            rotDir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(rotDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10);

            Debug.DrawRay(hit.point, diff, Color.blue);

            if (grounded)
                rb.AddForce(diff * forceMult);

            Debug.DrawRay(results[1], Vector3.up, Color.red);
        }

        //Debug.Log(grounded);

        float angleL = Mathf.Sin(groundTrack * 2) * 60;
        float angleR = Mathf.Sin(groundTrack * 2 + Mathf.PI) * 60;
        leftArm.transform.localRotation = Quaternion.Euler(angleL, 0, 0);
        rightArm.transform.localRotation = Quaternion.Euler(angleR, 0, 0);
    }

    public void nextTarget()
    {
        if (targets != null && targets.Length > currentTargetIndex + 1)
        {
            currentTargetIndex++;
            GoTo(targets[currentTargetIndex].position);
        }
    }
}
