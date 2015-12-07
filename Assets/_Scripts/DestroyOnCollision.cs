using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
    public string collisionTag;
    public GameObject hitFX;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            Instantiate(hitFX, transform.position, Quaternion.Euler(0.0f, -180.0f, 0.0f));
            Destroy(this.gameObject);
        }
	}
}
