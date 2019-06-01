using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PersonMovement : MonoBehaviour
{
    public Transform target;

    NavMeshAgent _agent;
    NavMeshAgent agent { get { if (!_agent) _agent = GetComponent<NavMeshAgent>(); return _agent; } }

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    public Vector3 gotoDestination;

    public void GoTo(Vector3 pos)
    {
        gotoDestination = pos;
        agent.destination = pos;
    }

    private void Start()
    {
        //agent.updatePosition = false;
        //agent.updateRotation = false;

        GoTo(target.position);
    }

    bool knocking;

    public void Knock(Vector3 force)
    {
        Vector3 velo = agent.velocity;
        agent.enabled = false;
        rb.isKinematic = false;
        rb.velocity = velo;
        rb.AddForce(force * 500);
        knocking = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!agent.enabled && knocking)
        {
            knocking = false;
        }
    }

    void TurnNavmeshOn()
    {
        agent.enabled = true;
        knocking = false;
        rb.isKinematic = true;

        agent.SetDestination(gotoDestination);
    }

    void Update()
    {
        Debug.Log(agent.isOnNavMesh);

        if (Input.GetKeyDown(KeyCode.G))
            Knock(Vector3.up);

        if (!agent.enabled && !knocking && agent.isOnNavMesh)
        {
            agent.SetDestination(gotoDestination);
        }

        //Vector3 velo = agent.desiredVelocity;
        //rb.velocity = velo;

        //agent.velocity = Vector3.right;

        //rb.AddForce(velo, ForceMode.VelocityChange);

        //agent.Warp(transform.position);
    }
}
