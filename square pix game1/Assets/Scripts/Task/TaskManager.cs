using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] List<Taks> taks;
    [SerializeField]List<Taks> taskInDay;
    [SerializeField] GameObject[] ligths_roms;

     List<int> JaSorteados = new List<int>();
     List<int> numerospossiveis = new List<int>();
     List<int> sorteador = new List<int>();
    int number;
    [SerializeField] List<GameObject> taksui;
    [SerializeField] int quantidTask;
    bool isresolve;
    [SerializeField]List<float> timer;
    [SerializeField] bool in_tutorial;
    public static TaskManager instance;

    [SerializeField]int t = 0;
    int p = 0;
    private void Awake()
    {
        if (instance == null)
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
        if (!in_tutorial)
        {

            quantidTask = Random.Range(2, 4);

            SpawTask();



          

        }

    }
    private void Update()
    {
        for (int i = 0; i < taskInDay.Count; i++)
        {

            if (taksui[i] != null)
            {
               
               
                if (t < taskInDay.Count)
                {
                    taksui[i].SetActive(true);


                    
                }

                else if (t < taksui.Count && t >= taskInDay.Count)
                {
                    taksui[t].gameObject.SetActive(false);
                    
                }

                if (t == taksui.Count)
                {
                    t = 0;
                }

                if (taskInDay[i].GETid == 1)
                {
                    ligths_roms[0].SetActive(true);
                }
                else if (taskInDay[i].GETid == 2)
                {
                    ligths_roms[1].SetActive(true);
                }
                else if (taskInDay[i].GETid == 3)
                {
                    ligths_roms[2].SetActive(true);
                }
                else if (taskInDay[i].GETid == 4)
                {
                    ligths_roms[3].SetActive(true);
                }

                t++;

                

            }

        }

        if (taskInDay.Count < 1)
        {
            GameManager.instance.NtextD = true;

            PlayerPrefs.SetInt("day", +1);
        }

    }

    void SpawTask()
    {

        int value = taks.Count;

        for (int i = 0; i < value; i++)
        {
            sorteador.Add(i);
        }

        numerospossiveis = sorteador;

        for (int i = 0; i < quantidTask; i++)
        {

            NumeroSorteado();

            taskInDay.Add(taks[number]);
            timer.Add(taks[number].Timer);

            taksui[i].SetActive(true);
        }


    }
 
    void NumeroSorteado()
    {

        int indice = Random.Range(0, numerospossiveis.Count);
        number = numerospossiveis[indice];
        JaSorteados.Add(number);
        numerospossiveis.Remove(numerospossiveis[indice]);



    }

  
    public List<Taks> Day
    {
        get
        {
            return taskInDay;
        }
        set
        {
            taskInDay = value;
        }
    }

    public bool Staustask
    {
        get
        {
            return isresolve;
        }

        set
        {
            isresolve = value;
        }
    }

}
