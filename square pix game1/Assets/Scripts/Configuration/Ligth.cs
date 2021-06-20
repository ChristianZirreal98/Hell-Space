using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligth : MonoBehaviour
{
    public bool on = true;
    [SerializeField]float timer = 10;
    [SerializeField]float count = 10;
    public static Ligth instace;
    [SerializeField] GameObject PointLight;


    public void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else instace = this;
    }

    private void Start()
    {
        count = timer;
    }

    private void Update()
    {       

        if (on == true)
        {
            PointLight.SetActive(true);
            count -= Time.deltaTime;

            if (count <= 0 )
            {
                on = false;

                if (count < 0)
                {
                    count = timer;
                }
            }
        }

        if (on == false)
        {
            PointLight.SetActive(false);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                on = true;

                PlayerInventory.instace.Baterypc -= 10;
            }
        }
    }
    public bool OnorOf
    {
        get
        {
            return on;
        }

        set
        {
            on = value;
        }
    }

    public float TimeLight
    {
        get
        {
            return count;
        }
    }
}
