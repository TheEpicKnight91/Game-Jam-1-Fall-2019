using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moth_spawning : MonoBehaviour
{
    public GameObject moth_prefab;

    private float spawn_time = 5.0f;
    private float max_amount = 22.0f;
    private float amount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_time <= 0.0f && amount < max_amount)
        {
            spawning();
        }
        spawn_time -= Time.deltaTime;
    }

    void spawning()
    {
        float pos_x = Random.Range(-4.7f, 4.7f);
        float pos_y = Random.Range(0.3f, 1.8f);
        float pos_z = Random.Range(4.3f, -4.3f);
        Instantiate(moth_prefab, new Vector3(pos_x, pos_y, pos_z),Quaternion.identity);
        amount++;
        spawn_time = 5.0f;
    }
}
