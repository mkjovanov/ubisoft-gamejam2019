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

    public void GoTo(Vector3 pos)
    {
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
        agent.enabled = false;
        rb.AddForce(force);
        knocking = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            Knock(Vector3.up);

        if (!agent.enabled && knocking)
        {
            agent.enabled = true;
        }

        Vector3 velo = agent.desiredVelocity;
        //rb.velocity = velo;

        //agent.velocity = Vector3.right;

        //rb.AddForce(velo, ForceMode.VelocityChange);

        //agent.Warp(transform.position);
    }
}
