using UnityEngine;
using System.Collections;

public class LoadButton : MonoBehaviour
{
    public float wait;
    public int levelToLoad;
    public GameObject fade;

	void LoadLevel()
    {
        fade.SendMessage("FadeOut");
    }
}
