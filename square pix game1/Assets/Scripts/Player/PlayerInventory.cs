using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<RawImage> imagesInventory;
    [SerializeField] RawImage fill_batery;
    [SerializeField] float batery;
    [SerializeField] Slider batery_slider;
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] List<Light> playerlight;
    float timer = 2f;
    float timer2;
    [SerializeField]bool inCharce = false;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI textButton;
    [SerializeField] TextMeshProUGUI bateryint;
    public static PlayerInventory instace;

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
        batery_slider.value = batery_slider.maxValue = batery; 
    }


    private void Update()
    {

        bateryint.text = batery.ToString("00");

        if (!MainMenu.instance.Get_pause)
        {

            if (batery <= 100)
            {
                playerlight[0].intensity = batery / 100;
                playerlight[1].intensity = batery / 100;



            }

            if (batery <= 0)
            {
                batery = 0;

                GameManager.instance.Awerstask = 3;


            }

            if (batery < 40)
            {
                animator.SetBool("lowH", true);

            }
            else
            {

                animator.SetBool("lowH", false);
            }


            if (inCharce == true)
            {
                timertext.gameObject.SetActive(true);
                PlayerMovement.instance.enabled = false;

                timer2 = (100 - batery) / 10;

                inCharce = false;

                bateryint.text = batery + " % ";

            }

            

        }


        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;
            timertext.text = timer2.ToString("0");
            if (timer2 <= 0)
            {

                if (TutorialManager.instance.Get_second_tt)
                {
                    TutorialManager.instance.Get_second_tt = false;
                }
                timertext.gameObject.SetActive(false);
                PlayerMovement.instance.enabled = true;
                timer2 = 0;

                inCharce = false;

                batery = 100;
            }
        }
        else
        {
            batery -= Time.deltaTime / 2;
        }


        batery_slider.value = batery;

    }


   
    public float Baterypc
    {
        get
        {
            return batery;
        }

        set
        {
            batery = value;
        }
    }
    
  
    public bool Charcing
    {
        get
        {
            return inCharce;
        }

        set
        {
            inCharce = true;
        }
    }

  
}
