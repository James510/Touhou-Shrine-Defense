using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float fireRate,nextFire;
    public GameObject ofuda;
    public float speed;
    private Rigidbody rb;
    Rect buttonRect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        buttonRect.x = 0.0f;
        buttonRect.y = 0.0f;
        buttonRect.width = 1000.0f;
        buttonRect.height = 800.0f;
        
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)&& buttonRect.Contains(new Vector2(touch.position.x, Screen.height - touch.position.y)))
                {
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        {
                            Vector2 sp = Camera.main.WorldToScreenPoint(transform.position);
                            Vector2 dir = (touch.position - sp).normalized;
                            GameObject bullet;
                            Rigidbody bulletRB;
                            float shotSpeed;
                            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                            shotSpeed = 2000.0f;
                            bullet = Instantiate(ofuda, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                            bulletRB = bullet.GetComponent<Rigidbody>();
                            bulletRB.AddForce(dir * shotSpeed);
                        }
                    }
                }
            }
        }
    }



    void FixedUpdate()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * speed, vertical * speed, 0.0f);
        rb.velocity = movement;
        //rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 1.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
    }
    void Fire(Vector3 pos)
    {
        
    }
}
