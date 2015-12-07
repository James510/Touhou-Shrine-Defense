using UnityEngine;
using System.Collections;

public class BasicFairyController : MonoBehaviour
{
    public float speed;
    public int hp;
    public GameObject deathFX;

	void Start ()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed);
	}
    void Update()
    {
        if(hp<1)
        {
            GameObject score = GameObject.Find("GameController");
            score.SendMessage("Score",50);
            Instantiate(deathFX, transform.position, Quaternion.Euler(0.0f,180.0f,0.0f));   
            Destroy(this.gameObject);
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GameObject score = GameObject.Find("GameController");
            score.SendMessage("Score", 1);
            hp--;
        }
    }
}
