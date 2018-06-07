using UnityEngine;

public class BonusRotatorSolo : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
}
