﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpawner : MonoBehaviour
{
    public Bolt Bolt;
    public GameObject Ground;
    public LayerMask LayerHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnThunder();
        }
    }

    private void SpawnThunder()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, 200, LayerHit))
        {
            var hitPos = hit.point;
            Instantiate(Bolt, hitPos + new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
    }
}