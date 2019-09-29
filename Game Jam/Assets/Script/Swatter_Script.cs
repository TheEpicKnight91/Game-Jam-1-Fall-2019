using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatter_Script : MonoBehaviour
{
    public Rigidbody Rigid_Body;
    public float Speed;
    private Vector3 Move_Vertical;
    private Vector3 Move_Horizontal;
    private Quaternion Original_Rotation;
    public Vector3 Original_Position;
    private GameObject Clone;
    public GameObject Moth;
    public GameObject Collection;
    private bool Once = true;
    private float Tipsy_Timer = 0;
    private float Check = 0;
    public AudioSource Sound_Player;
    void FixedUpdate()
    {
        Check += Time.deltaTime;

        if (Check >= 5)
        {
            Too_Tipsy();
            Check = 0;
        }

        float Move_Horizontal = Input.GetAxis("Horizontal");
        float Move_Vertical = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(Move_Horizontal, Move_Vertical, 0.0f);

        Rigid_Body.AddForce(Movement * Speed);
        Original_Rotation = this.transform.rotation;

        if (!Sound_Player.isPlaying)
            Sound_Player.enabled = false;

        if (Input.GetButton("Fire1"))
            Rotate();

        if (Input.GetButtonUp("Fire1"))
        {
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
            this.transform.position = Original_Position;
        }
    }

    void Rotate()
    {
        this.transform.Rotate(-5 * 3, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fly")
        {
            int Chance = Random.Range(0, 2);

            if (Chance == 0 && Once)
            {
                GameObject Clone = Instantiate(Moth, other.transform.position, Quaternion.identity);
                Sound_Player.enabled = true;
                Once = false;

                if (!Sound_Player.isPlaying)
                    Sound_Player.enabled = false;
            }

            if (Chance == 1)
                Destroy(other.gameObject);
        }
    }

    void Too_Tipsy()
    {
        int Tipsy_Chance = Random.Range(0, 2);
        print(Tipsy_Chance);

        if (Tipsy_Chance == 0)
        {
            Collection.SetActive(false);
            Tipsy_Timer += Time.deltaTime;
        }

        if (Tipsy_Chance == 1)
            Collection.SetActive(true);
    }
}
