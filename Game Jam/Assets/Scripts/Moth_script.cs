using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth_script : MonoBehaviour
{
    private float teleport_timer = 4.0f;
    public GameObject computer;
    private Vector3 end_pos;
    private bool damage_done = false;
    // Start is called before the first frame update
    void Start()
    {
        computer = GameObject.Find("Computer");
        end_pos = new Vector3(computer.transform.position.x, computer.transform.position.y + 0.5f, computer.transform.position.z - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (transform.position - end_pos).sqrMagnitude;
        if (dist <= 0.05f && damage_done == false)
        {
            computer.GetComponent<computer_script>().Health-=2;
            Destroy(this.gameObject);
        }
        if (teleport_timer <= 0.0f)
        {
            float pos_x = Random.Range(-1.819f, 2.286f);
            float pos_y = Random.Range(0.674f, 1.825f);
            float pos_z = Random.Range(3.319f, 4.222f);
            transform.position = new Vector3(pos_x, pos_y, pos_z);
            teleport_timer = 10.0f;
        }
        transform.rotation = Quaternion.LookRotation((computer.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Euler(-90,transform.position.y, transform.rotation.z);
        transform.position = Vector3.Lerp(transform.position, end_pos, 0.09f * Time.deltaTime);
        teleport_timer -= Time.deltaTime;
    }
}
