using UnityEngine;
using UnityEngine.Networking;

public class BonusRotator : NetworkBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}