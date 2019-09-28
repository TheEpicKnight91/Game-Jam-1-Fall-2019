using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer_script : MonoBehaviour
{
    public float Health = 100.0f;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<Text>().text = "Computer Health: 100";
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<Text>().text = "Computer Health: " + Health;
    }
}
