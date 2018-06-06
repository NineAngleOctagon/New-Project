using UnityEngine;
using UnityEngine.Networking;

public class BonusRotator : NetworkBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
}