using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int day;
    int daysSurivive;
    bool nextday;
    int life;
    [SerializeField] TextMeshProUGUI navetext;
    [SerializeField] TextMeshProUGUI daytext;
    public static GameManager instance;
    [SerializeField] GameObject panel_D;
    [SerializeField] GameObject Painel;
    [SerializeField] GameObject panel_tuto;
    [SerializeField] TextMeshProUGUI resultText;
    

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
        Time.timeScale = 0;

        Application.targetFrameRate = 300;

        life = PlayerPrefs.GetInt("taskfailure");
        

        day = PlayerPrefs.GetInt("day");
        daysSurivive = PlayerPrefs.GetInt("DaysSurvive");

        if (day <= 0)
        {
            day = 1;
        }

        if (panel_tuto.activeInHierarchy)
        {
            MainMenu.instance.Get_pause = true;

        }
        else
        {
            MainMenu.instance.Get_pause = false;
        }


    }


    private void Update()
    {
      
        if (day > 1)
        {
            if (!MainMenu.instance.Get_pause)
            {
                panel_tuto.SetActive(false);
                Time.timeScale = 1;
            }
        }

        daytext.text = "Day = " + day.ToString();


        if (nextday == true && day < daysSurivive)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("day", day+=1);
            nextday = false;
        }

        else if (day >= daysSurivive && nextday == true)
        {
            PlayerPrefs.SetInt("day", 1);
            Painel.SetActive(true);
            resultText.text = "Your Survive ";
        }

        else if (life >= 3)
        {
            PlayerPrefs.SetInt("day", 1);
            Painel.SetActive(true);
            Time.timeScale = 0;
            resultText.text = " Dead ";
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0;
            MainMenu.instance.Get_pause = true;
            panel_D.SetActive(true);
        }
    }

    public bool NtextD
    {
        get
        {
            return nextday;
        }

        set
        {
            nextday = value;
        }
    }

    public void Panel_D(GameObject panel)
    {
        panel.SetActive(false);
        MainMenu.instance.Get_pause = false;
        Time.timeScale = 1;
    }

    public int Awerstask
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

    

}
