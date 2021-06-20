using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLoading;
    [SerializeField] Slider slider;
    [SerializeField] GameObject panelLoading;
    [SerializeField]bool pause;
    [SerializeField] GameObject painelPause;

    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pause == true)
            {
                painelPause.SetActive(false);
                Time.timeScale = 1;
                pause = false;
            }

            else
            {
                painelPause.SetActive(true);
                Time.timeScale = 0;
                pause = true;
            }
        }
    }
    public void ActivePainel(GameObject Painel)
    {
        Painel.SetActive(true);

    }

    public void DesactivePainel(GameObject Painel)
    {
        Painel.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void SelectSettings(int Days)
    {
        PlayerPrefs.SetInt("DaysSurvive", Days);

        Time.timeScale = 1;
    }

    public void SelectGAme(int index)
    {
        StartCoroutine(LoadGame(index));

        if (panelLoading != null)
        {
            panelLoading.SetActive(true);
        }
       
    }

    public void Pause(GameObject Painel)
    {
        if (pause == true)
        {
            Painel.SetActive(false);
            Time.timeScale = 1;
            pause = false;
        }

        else
        {
            Painel.SetActive(true);
            Time.timeScale = 0;
            pause = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadGame(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        if (!operation.isDone)
        {
            if (textLoading != null && slider != null)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                textLoading.text = (progress * 100).ToString("0") + "%";

                slider.value = progress;
            }

            yield return null;
        }


    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public bool Get_pause
    {
        get
        {
            return pause;
        }
        set
        {
            pause = value;
        }
    }
    
}
