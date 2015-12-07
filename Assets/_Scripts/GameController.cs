using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text score;
    public GameObject reimu,fairy1,specialBar;
    public float waveTimer,special;
    private int points,wave;

    void Start()
    {
        special = 0;
        points = 0;
        wave = 0;
    }
    void Update()
    {
        
        if(Time.time > waveTimer)
        {
            //Debug.Log("Running");
            enemySpawn();
        }
        if (special > 1)
            special = 1;
        
    }
    void SpellCardAttack()
    {
        special = 0;
        specialBar.SendMessage("Set", special);
    }
    void Score(int x)
    {
        special += 0.0001f;
        specialBar.SendMessage("Set", special);
        
        points += x;
        score.text = "SCORE : " + points;
    }
    void enemySpawn()
    {
        int roll = Random.Range(0, 100);
        //Debug.Log(roll);
        if (roll == 1)
        {
            //Debug.Log("rolling");
            GameObject enemy = Instantiate(fairy1,new Vector3(-10.0f, Random.Range(-4.0f, 2.0f), -1.0f), Quaternion.identity) as GameObject;
        }
    }
}
