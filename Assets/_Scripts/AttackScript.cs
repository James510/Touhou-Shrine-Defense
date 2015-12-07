using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour
{
    public GameObject reimu;

	void OnTouchStay(Vector3 pos)
    {
        //Debug.Log("Fire");
        reimu.SendMessage("Fire",pos);
    }
}
