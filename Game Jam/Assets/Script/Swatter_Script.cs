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
    public bool Once = true;
    private float Tipsy_Timer = 0;
    private float Check = 0;
    public AudioSource Sound_Player;
    public AudioSource What_Player;
    public AudioClip Regular;
    public AudioClip Bruh;
    public AudioClip Gone;
    public float Low_X, High_X, Low_Y, High_Y;

    void Start()
    {
        Low_X = this.transform.position.x - 10;
        High_X = this.transform.position.x + 10;
        Low_Y = this.transform.position.y - 8;
        High_Y = this.transform.position.y + 8;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        Check += Time.deltaTime;

        if (Check >= 5)
        {
            Too_Tipsy();
            Once = true;
            What_Player.enabled = false;
            Check = 0;
        }

        if (this.transform.position.x <= Low_X || this.transform.position.x >= High_X || this.transform.position.y <= Low_Y || this.transform.position.y >= High_Y)
        {
            Speed = 0;
            Rigid_Body.velocity = new Vector3(0, 0, 0);
            this.transform.position = Original_Position;
        }

        else
            Speed = 1;

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

            int Chance = Random.Range(0, 2);

            if (Chance == 0)
            {
                Sound_Player.clip = Regular;
                Sound_Player.enabled = true;
            }

            if (Chance == 1)
            {
                Sound_Player.clip = Bruh;
                Sound_Player.enabled = true;
            }
        }
    }

    void Rotate()
    {
        this.transform.Rotate(5 * 3, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fly")
        {
            int Chance = Random.Range(0, 2);

            if (Chance == 0 && Once)
            {
                GameObject Clone = Instantiate(Moth, other.transform.position, Quaternion.identity);
                this.transform.position = Original_Position;
                What_Player.enabled = true;
                Once = false;
            }

            if (Chance == 1)
            {
                ParticleSystem part = other.GetComponent<ParticleSystem>();
                part.Play();
                print("hit");
                MeshRenderer mesh = other.GetComponent<MeshRenderer>();
                mesh.enabled = false;
                Destroy(other.gameObject, 3);
            }
        }
    }

    void Too_Tipsy()
    {
        int Tipsy_Chance = Random.Range(0, 2);

        if (Tipsy_Chance == 0 && !Sound_Player.isPlaying)
        {
            Collection.SetActive(false);
            Sound_Player.clip = Gone;
            Sound_Player.enabled = true;
            Tipsy_Timer += Time.deltaTime;
        }

        if (Tipsy_Chance == 1)
            Collection.SetActive(true);
    }
}
