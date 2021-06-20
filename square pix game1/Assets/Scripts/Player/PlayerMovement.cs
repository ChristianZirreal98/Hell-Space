using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] int speed;
    //[SerializeField] CharacterController characterController;
    Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] GameObject PainelLife;
    [SerializeField] bool in_tutorial;
    [SerializeField] AudioSource player_running_sound;
    Vector3 movevelocity;
    public static PlayerMovement instance;
    bool camselect = true;
    [SerializeField]float timer = 10;    
    [SerializeField]int life = 2;


    /*Vector3 velocity;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float groundistance;
    [SerializeField] LayerMask groundMask;*/

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Time.timeScale = 1;
       
    }

    void Update()
    {


       
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        

        RaycastHit raylength;

        if (Physics.Raycast(cameraRay, out raylength))
        {

            transform.LookAt(new Vector3( raylength.point.x, transform.position.y, raylength.point.z));
        }

        if (!MainMenu.instance.Get_pause)
        {
            Move();
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

     

        Vector3 movement = new Vector3(moveX, 0, moveY);

        movement.Normalize();

        if (moveX != 0 || moveY != 0)
        {
            rb.velocity = movement * speed;
        }
        else
        {
            rb.velocity = new Vector3 (0,0);
        }
    }

    

    public int Getlife
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }
    public bool Orca
    {
        get
        {
            return in_tutorial;
        }
    }



    public Rigidbody GetRb
    {
        get
        {
            return rb;
        }

        set
        {
            rb = value;
        }
    }
}
