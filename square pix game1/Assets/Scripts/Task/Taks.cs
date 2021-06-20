using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = " New Task")]
public class Taks : ScriptableObject
{
    [SerializeField]string taksname;
    [SerializeField] int id;
    [SerializeField] float timerTask ;
    [SerializeField] int bateryPorcentTask;
    [SerializeField] string localTask;
    [SerializeField] Color color;
   
    public int GETid
    {
        get
        {
            return id;
        }
    }
    public string Name
    {
        get
        {
            return taksname;
        }

       
    }
    public float Timer
    {
        get
        {
            return timerTask;
        }
    }
    public int Baterytaks
    {
        get
        {
            return bateryPorcentTask;
        }
    }
    public string local
    {
        get
        {
            return localTask;
        }

        
    }

    public Color Get_color
    {
        get
        {
            return color;
        }

        set
        {
            value = color;
        }
    }
    

    
}
