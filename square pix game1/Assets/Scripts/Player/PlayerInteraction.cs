using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instace;

    [SerializeField] List<RawImage> close_doors_image;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Image[] taskui;
    [SerializeField] Sprite[] task_locked;
    [SerializeField] Image panel_D;
    [SerializeField] Sprite[] Sprite_panel_d;
    [SerializeField] Renderer material;
    [SerializeField] Texture[] maps;
    [SerializeField] Sprite[] task_open;
    [SerializeField] GameObject[] doorprefab;
    [SerializeField]bool noiseMosnter;
    [SerializeField] bool in_tutorial;
    [SerializeField] AudioSource open_doors_FX;
    [SerializeField] AudioSource solve_task_FX;
    int itenindex;
  
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
        if (maps != null)
        {

            material.material.SetTexture("_main_texture", maps[0]);
            
        }
        panel_D.sprite = Sprite_panel_d[0];
    }

    private void Update()
    {
        if (!PlayerMovement.instance.Orca)
        {
            if (doorprefab[1] != null && doorprefab[3] != null)
            {


                if (close_doors_image[1].gameObject.activeInHierarchy && close_doors_image[3].gameObject.activeInHierarchy)
                {

                    for (int i = 0; i < TaskManager.instance.Day.Count; i++)
                    {
                        if (TaskManager.instance.Day[i].GETid == 1)
                        {
                            taskui[i].sprite = task_locked[3];
                            

                        }
                        if (TaskManager.instance.Day[i].GETid == 3)
                        {
                            taskui[i].sprite = task_locked[1] ;                                                      
                        }

                       

                    }
                }
                else
                {

                    for (int i = 0; i < TaskManager.instance.Day.Count; i++)
                    {
                        if (TaskManager.instance.Day[i].GETid == 1)
                        {
                            taskui[i].sprite = task_open[3] ;
                        }
                        if (TaskManager.instance.Day[i].GETid == 3)
                        {
                            taskui[i].sprite = task_open[1];
                        }



                    }
                    material.material.SetTexture("_MainTex", maps[1]);
                    panel_D.sprite = Sprite_panel_d[1];
                }
            }
            if (doorprefab[0] != null && doorprefab[2] != null)
            {


                if (close_doors_image[0].gameObject.activeInHierarchy && close_doors_image[2].gameObject.activeInHierarchy)
                {
                    for (int i = 0; i < TaskManager.instance.Day.Count; i++)
                    {
                        if (TaskManager.instance.Day[i].GETid == 2)
                        {
                            taskui[i].sprite = task_locked[0];
                        }
                        if (TaskManager.instance.Day[i].GETid == 4)
                        {
                            taskui[i].sprite = task_locked[2];
                        }



                    }
                }
                else
                {
                    for (int i = 0; i < TaskManager.instance.Day.Count; i++)
                    {
                        if (TaskManager.instance.Day[i].GETid == 2)
                        {
                            taskui[i].sprite = task_open[0];
                        }
                        if (TaskManager.instance.Day[i].GETid == 4)
                        {
                            taskui[i].sprite = task_open[2];
                        }

                        material.material.SetTexture("_MainTex", maps[2]);
                        panel_D.sprite = Sprite_panel_d[2];

                    }
                }
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {


        if (other != null)
        {
            if (other.gameObject.CompareTag("button1"))
            {

                textMeshPro.gameObject.SetActive(true);
                itenindex = 3;
                textMeshPro.text = " Open doors, orange rom y  blue rom";


                InputB(other.gameObject, 0);
            }

            if (other.gameObject.CompareTag("button2"))
            {

                textMeshPro.gameObject.SetActive(true);
                itenindex = 4;
                textMeshPro.text = " Open doors, green rom y yellow rom ";

                InputB(other.gameObject, 0);
            }

            if (other.gameObject.CompareTag("batery"))
            {
                for (int i = 0; i < TaskManager.instance.Day.Count; i++)
                {
                    if (other.GetComponent<TaskPainel>().Getid == TaskManager.instance.Day[i].GETid)
                    {
                        textMeshPro.gameObject.SetActive(true);
                        textMeshPro.text = " Solve task";

                        itenindex = 5;

                        InputB(other.gameObject, i);
                    }
                }
            }

            if (other.gameObject.CompareTag("c"))
            {
                textMeshPro.gameObject.SetActive(true);
                itenindex = 1;
                textMeshPro.text = " Recharge the battery";

                InputB(other.gameObject, 0);
            }

        }

        else
        {
            textMeshPro.gameObject.SetActive(false);
        }

    }
    private void OnTriggerExit(Collider other)
    {
       
       textMeshPro.gameObject.SetActive(false);

      
    }
    void InputB(GameObject Object , int i)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itenindex == 1)
            {
                textMeshPro.gameObject.SetActive(false);

                if (PlayerMovement.instance.Orca)
                {
                    TutorialManager.instance.Get_four_tt = false;
                }

                if (PlayerInventory.instace.Baterypc < 100)
                {
                    PlayerInventory.instace.Charcing = true;
                   
                }
                
            }

           

            if (itenindex == 4)
            {
                if (doorprefab[1] != null && doorprefab[3] != null)
                {
                    doorprefab[0].SetActive(true);
                    doorprefab[1].SetActive(false);
                    doorprefab[2].SetActive(true);
                    doorprefab[3].SetActive(false);

                    if (!open_doors_FX.isPlaying)
                    {
                        open_doors_FX.Play();
                    }

                    if (close_doors_image.Count > 0)
                    {
                        close_doors_image[0].gameObject.SetActive(false);
                        close_doors_image[1].gameObject.SetActive(true);
                        close_doors_image[2].gameObject.SetActive(false);
                        close_doors_image[3].gameObject.SetActive(true);

                    }
                }

            }

            if (itenindex == 3)
            {
                doorprefab[0].SetActive(false);
                doorprefab[1].SetActive(true);
                doorprefab[2].SetActive(false);
                doorprefab[3].SetActive(true);

                if (!open_doors_FX.isPlaying)
                {
                    open_doors_FX.Play();
                }

                if (close_doors_image.Count > 0)
                {
                    close_doors_image[0].gameObject.SetActive(true);
                    close_doors_image[1].gameObject.SetActive(false);
                    close_doors_image[2].gameObject.SetActive(true);
                    close_doors_image[3].gameObject.SetActive(false);

                }

                if (in_tutorial)
                {
                    if (TutorialManager.instance.Get_first_tt)
                    {
                        TutorialManager.instance.Get_first_tt = false;

                        TutorialManager.instance.Get_second_tt = true;
                        
                    }
                }

            }

            if (itenindex == 5)
            {
                if (PlayerInventory.instace.Baterypc >= TaskManager.instance.Day[i].Baterytaks)
                {
                    PlayerInventory.instace.Baterypc -= TaskManager.instance.Day[i].Baterytaks;

                    TaskManager.instance.Day.RemoveAt(i);

                    textMeshPro.gameObject.SetActive(false);

                    if (!solve_task_FX.isPlaying)
                    {
                        solve_task_FX.Play();
                    }

                    if (in_tutorial)
                    {

                        TutorialManager.instance.Get_third_tt = false;
                        TutorialManager.instance.Get_four_tt = true;

                    }
                }
            }


        }
    }
    
    public bool Noise
    {
        get
        {
            return noiseMosnter;
        }

        set
        {
            noiseMosnter = value;
        }
    }

}
