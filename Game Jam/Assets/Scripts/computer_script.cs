using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer_script : MonoBehaviour
{
    public float Health = 100.0f;
    public Text txt;
    public AudioSource Sound_Play;

    void Start()
    {
        txt.GetComponent<Text>().text = "Computer Health: " + Health;
    }

    void Update()
    {
        txt.GetComponent<Text>().text = "Computer Health: " + Health;
        if (Health <= 0.0f)
        {
            Time.timeScale = 0;
            Sound_Play.enabled = true;
        }

        if (!Sound_Play.isPlaying)
            Sound_Play.enabled = false;
    }
}
