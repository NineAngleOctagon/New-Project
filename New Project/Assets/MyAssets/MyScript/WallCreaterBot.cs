﻿using UnityEngine;
using UnityEngine.Networking;

public class WallCreaterBot : NetworkBehaviour
{
    public Rigidbody rb;
    private TrailRenderer trail;
    private int gapTrail;
    private int frequency;
    private int distance;

    private void Start()
    {
        gapTrail = 6;
        frequency = 2;
        distance = 6;
    }
    void Update()
    {
        trail = rb.GetComponent<TrailRenderer>();

        if (trail.positionCount > gapTrail)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.AddComponent<Rigidbody>();
            cube.AddComponent<NetworkIdentity>();
            cube.GetComponent<Rigidbody>().mass = int.MaxValue;
            cube.GetComponent<Rigidbody>().useGravity = false;
            Vector3 pos = trail.GetPosition(trail.positionCount - distance);
            if ((pos.x <= -15 || pos.x >= 15 || pos.z <= 45)
                && (pos.x <= -15 || pos.x >= 15 || pos.z >= -45)
                && (pos.x <= -315 || pos.x >= -285 || pos.z <= -155)
                && (pos.x <= -315 || pos.x >= -285 || pos.z >= -245)
                && (pos.x >= 177.5 || pos.x <= 147.5 || pos.z <= -255)
                && (pos.x >= 252.5 || pos.x <= 222.5 || pos.z <= -255)
                && pos.y <= 30)
            {
                cube.transform.position = pos;
                gapTrail = trail.positionCount + frequency;

                cube.GetComponent<Rigidbody>().isKinematic = true;

                cube.layer = 1;

                cube.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                Destroy(cube);
            }
        }
    }
}

