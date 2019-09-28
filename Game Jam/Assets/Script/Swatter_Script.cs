using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatter_Script : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            this.transform.position += new Vector3(-1, 0, 0);
    }
}
