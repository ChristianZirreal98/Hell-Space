using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] float timer;
    [SerializeField] List<Transform> MosnterSpawners;
    [SerializeField] List<int> JaSorteados = new List<int>();
    [SerializeField] List<GameObject> monsterPrefabs = new List<GameObject>();
    [SerializeField] List<int> numerospossiveis = new List<int>();
    [SerializeField] List<int> sorteador = new List<int>();
    [SerializeField]int maxMonsterInScene;
    int monsterInScene;
    [SerializeField] int time;      
    [SerializeField] List<Transform> waypoints;
    public static Spawn instance;

    [SerializeField] int number;

    private void Awake()
    {

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

        timer = time;
        SpawnMosnters();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("DaysSurvive") == 5)
        {
            if (monsterInScene < maxMonsterInScene + PlayerPrefs.GetInt("day"))
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = time;
                    SpawnMosnters();
                }
            }

        }

        else if (PlayerPrefs.GetInt("DaysSurvive") == 10)
        {
            if (monsterInScene < maxMonsterInScene + (PlayerPrefs.GetInt("day") * 2))
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = time;
                    SpawnMosnters();
                }
            }

        }

        else if (PlayerPrefs.GetInt("DaysSurvive") == 15)
        {
            maxMonsterInScene *= PlayerPrefs.GetInt("day");

            if (maxMonsterInScene > 0)
            {
                if (monsterInScene < maxMonsterInScene )
                {
                    timer -= Time.deltaTime;

                    if (timer <= 0)
                    {
                        timer = time;
                        SpawnMosnters();
                    }
                }
            }

            else
            {
                if (monsterInScene < 10)
                {
                    timer -= Time.deltaTime;

                    if (timer <= 0)
                    {
                        timer = time;
                        SpawnMosnters();
                    }
                }
            }

           

        }


    }

    void SpawnMosnters()
    {
        int value = MosnterSpawners.Count;

        for (int i = 0; i < value; i++)
        {
            sorteador.Add(i);
        }

        numerospossiveis = sorteador;

        for (int i = 0; i < MosnterSpawners.Count; i++)
        {          

            if (monsterInScene < maxMonsterInScene)
            {
                NumeroSorteado();
                Instantiate(monsterPrefabs[number].gameObject, MosnterSpawners[i].transform.position, monsterPrefabs[number].transform.rotation);
                monsterInScene++;
            }

        }

      
    }

    void NumeroSorteado( )
    {

        int indice = Random.Range(0, numerospossiveis.Count);
        number = numerospossiveis[indice];
        JaSorteados.Add(number);
        numerospossiveis.Remove(numerospossiveis[indice]);


        
    }

    public List<Transform> WaypoinstTRAns
    {
        get
        {
            return waypoints;
        }
    }

    public int MonsterScene
    {
        get
        {
            return monsterInScene;
        }

        set
        {
            monsterInScene = value;
        }
    }

}