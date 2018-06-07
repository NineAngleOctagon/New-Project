using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idetectedsmth : MonoBehaviour {

    public bool detected = false;
    public GameObject cube;
    public GameObject bot;

    private void OnTriggerEnter(Collider other)
    {
        detected = true;
    }

    private void Update()
    {
        if (cube.transform.position.x >= 70 || cube.transform.position.x <= -70)
        {
            detected = true;
        }

        if ((cube.transform.position.z >= 70 || cube.transform.position.z <= -70))
        {
            detected = true;
        }
    }
}
