using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer_script : MonoBehaviour
{
    public float Health = 10.0f;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<Text>().text = "Computer Health: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<Text>().text = "Computer Health: " + Health;
        if (Health <= 0.0f)
        {
            Time.timeScale = 0;

        }
    }
}
