using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    bool trade_text = false;
    bool first_tutorial = true;
    bool second_tutorial = false;
    bool third_tutorial = false;
    bool four_tutorial = false;
    bool spawned_enemy = false;

    [SerializeField]bool in_tutorial;

    [Header("Tutorial Settings")]
    [SerializeField] List<GameObject> task_objs;
    [SerializeField] List<GameObject> task_ui;
    [SerializeField] TextMeshProUGUI text_tuttorial;
    [SerializeField] List<TextMeshProUGUI> commanders_tutorial_text;
    [SerializeField] GameObject exit_panel_tutorial;
    [SerializeField] List<DialogueText> dialogue_texts;
    [SerializeField] Transform spawn;
    [SerializeField] List<GameObject> light_tutorial_explication;
    [SerializeField] GameObject enemy_tutorial;



    public static TutorialManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    private void Start()
    {

        MainMenu.instance.Get_pause = false;
        
    }

    private void Update()
    {
        if (in_tutorial)
        {
            if (first_tutorial == false)
            {
                if (second_tutorial == false)
                {
                    if (third_tutorial == false)
                    {
                        for (int i = 0; i < task_objs.Count; i++)
                        {
                            task_objs[i].SetActive(false);
                            task_ui[i].SetActive(false);
                        }

                        if (four_tutorial == false)
                        {
                            exit_panel_tutorial.SetActive(true);

                            in_tutorial = false;

                            TutorialSettings(0, 4);

                        }

                        else
                        {
                           
                            TutorialSettings(0, 3);
                        }
                    }

                    else
                    {

                        for (int i = 0; i < task_objs.Count; i++)
                        {
                            task_objs[i].SetActive(true);
                            task_ui[i].SetActive(true);
                        }

                       

                        TutorialSettings(0, 2);
                    }

                }
                else
                {
                    if (enemy_tutorial == null)
                    {
                        
                        second_tutorial = false;
                        third_tutorial = true;
                    }

                    TutorialSettings(0, 1);
                }
            }
            

            else
            {
                
                TutorialSettings(0, 0);
            }

        }

    }

    void TutorialSettings(int index_text, int index_dialogue)
    {
        if (in_tutorial)
        {
            if (trade_text)
            {
                text_tuttorial.text = dialogue_texts[index_dialogue].Get_text[index_text + 1];
            }
            else
            {
                text_tuttorial.text = dialogue_texts[index_dialogue].Get_text[index_text];
            }

           
        }
    }

    public void Scene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public bool Get_first_tt
    {
        get
        {
            return first_tutorial;
        }

        set
        {
            first_tutorial = value;
        }
    }

    public bool Get_second_tt
    {
        get
        {
            return second_tutorial;
        }

        set
        {
            second_tutorial = value;
        }
    }

    public bool Get_four_tt
    {
        get
        {
            return four_tutorial;
        }

        set
        {
            four_tutorial = value;
        }
    } 

    public bool Get_third_tt
    {
        get
        {
            return third_tutorial;
        }

        set
        {
            third_tutorial = value;
        }
    }

    

}
