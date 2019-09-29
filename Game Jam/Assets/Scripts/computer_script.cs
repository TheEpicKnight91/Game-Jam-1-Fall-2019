using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class computer_script : MonoBehaviour
{
    public float Health = 100.0f;
    public Text txt;
    public AudioSource Sound_Play;
    public GameObject Dialog;

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
            Dialog.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!Sound_Play.isPlaying)
            Sound_Play.enabled = false;
    }
}
