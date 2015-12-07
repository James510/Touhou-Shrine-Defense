using UnityEngine;
using System.Collections;

public class PointAtVelocity : MonoBehaviour
{
    void Start()
    {

    }
	void Update ()
    {
        Vector3 dir = transform.GetComponent<Rigidbody>().velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
