﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Change : MonoBehaviour
{

    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AS.isPlaying == false)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }
    }
}
