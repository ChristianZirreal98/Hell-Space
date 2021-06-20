using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] Transform pointTopveiw;
    [SerializeField] int range;
    bool not_shot;


    [SerializeField] BulletController bullet;
    [SerializeField] AudioSource shootAudio;
    float timer;



    private void Update()
    {
        not_shot = MainMenu.instance.Get_pause;
        

        if (!not_shot)
        {
            if (Input.GetMouseButtonDown(0) && timer <= 0 && Time.timeScale == 1)
            {

                if (PlayerInventory.instace.Baterypc > 0)
                {
                    timer = 1;
                    gunTopView();
                    shootAudio.pitch = Random.Range(1, 3);
                    shootAudio.Play();
                    PlayerInventory.instace.Baterypc--;
                }

            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
    }
   
    void gunTopView()
    {

         BulletController newbullet = Instantiate(bullet, pointTopveiw.position,pointTopveiw.rotation);

       

         Destroy(newbullet.gameObject, 5);
       
    }

   
   
}
