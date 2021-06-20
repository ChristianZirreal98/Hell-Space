using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Enemy instance;
    float visiontime = 0f;
    float waypointtimer;
    [SerializeField]bool Stoped = false;
    [SerializeField] int Waytimer;
    [SerializeField] float timer = 20;
    bool invion = false;
    bool canTakeDamage = true;
    bool noiseplay = false;
    int life = 2;
    public int i = 0;
    [SerializeField] int level;
    [SerializeField]int atack;
    [SerializeField] int heal;
    [SerializeField]NavMeshAgent agent;
    [SerializeField] AudioSource noisemonster;
    [SerializeField] AudioSource monsterDeadsound;
    [SerializeField] Transform Player;
    [SerializeField] GameObject death_effect;
    [SerializeField]List<Transform> waypoints;
    [SerializeField] int numberofWaypoints;
    [SerializeField] GameObject Rastros;    
    [SerializeField] int range;
    [SerializeField] bool in_tuttorial;
   

    private void Awake()
    {
        atack = Random.Range(2, 5);

        if (instance != null)
        {
            instance = this;
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {

        if (!in_tuttorial)
        {
            waypoints = Spawn.instance.WaypoinstTRAns;

            Player = GameObject.FindGameObjectWithTag("Player").transform;

            agent = GetComponent<NavMeshAgent>();

            heal = Random.Range(3, 6);

            waypointtimer = Waytimer;

            i = Random.Range(0, waypoints.Count);
        }


    }
    private void Update()
    {      
        if (life <= 0)
        {
            Die();
        }

        else if(Time.timeScale == 1 && life > 0 && !in_tuttorial)
        {
            Vison();          

            if (invion == true)
            {
                agent.SetDestination(Player.position);
                visiontime -= Time.deltaTime;

                if (visiontime < 0)
                {
                    visiontime = timer;
                    invion = false;
                }
            }

            else if (invion == false)
            {
                Movement();
            }

            

        }


        if (Time.timeScale == 0)
        {
            noisemonster.Stop();
        }
    }


    void UpLevel()
    {
        if (level > 2)
        {
            life = 3;
        }
        heal += Random.Range(1, 2);
        atack += Random.Range(1, 3);
    }
    public void TakeDamage(int damage)
    {
        life -= damage;

        monsterDeadsound.Play();

    }
    public void Movement()
    {
        if (invion == false)
        {
            waypointtimer -= Time.deltaTime;

            if (waypointtimer < 0)
            {
                i = Random.Range(0, waypoints.Count);
                waypointtimer = Waytimer;
            }

            agent.SetDestination(waypoints[i].position);
        }
        else
        {
            waypointtimer = Waytimer;
        }
    }
    void Vison()
    {

        if (monsterDeadsound.isPlaying == true)
        {
            noisemonster.Stop();
            noiseplay = false;
        }

        if (Vector3.Distance(transform.position, Player.position) <= range + 20)
        {


            invion = true;

            if (noisemonster.isPlaying == false && monsterDeadsound.isPlaying == false)
            {

                if (noiseplay == true)
                {
                    noiseplay = false;
                    PlayerInteraction.instace.Noise = false;
                }

                else if (PlayerInteraction.instace.Noise == false)
                {
                    noisemonster.Play();
                    noiseplay = true;
                    PlayerInteraction.instace.Noise = true;
                }


            }



        }
        else if (Vector3.Distance(transform.position, Player.position) > range + 20)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 20;
                invion = false;
            }

            if (noisemonster.isPlaying == true)
            {

                noiseplay = false;
                PlayerInteraction.instace.Noise = false;
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range + 20);
    }
    void Die()
    {
        agent = null;
        PlayerInteraction.instace.Noise = false;

        if (!in_tuttorial)
        {
            Spawn.instance.MonsterScene--;

        }

        else
        {
            TutorialManager.instance.Get_third_tt = false;
            TutorialManager.instance.Get_four_tt = true;
        }

        GameObject particle = Instantiate(death_effect, transform.position, Quaternion.identity);

        Destroy(particle, 2);

        Destroy(gameObject);
    }

   
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy OtherEnemy = other.gameObject.GetComponent<Enemy>();

            if (atack > OtherEnemy.atack || heal > OtherEnemy.heal)
            {
                level += 1;
                UpLevel();
                
            }
            else if(atack < OtherEnemy.atack )
            {
                heal = 0;
                Die();
            }

            
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);

            Destroy(other.gameObject);
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (canTakeDamage)
            {

                if (PlayerMovement.instance.Orca)
                {
                    
                    Die();

                }

                else
                {
                    
                        GameManager.instance.Awerstask = 3;
                    
                }
            }


            
        }
       
    }

   



}

   

