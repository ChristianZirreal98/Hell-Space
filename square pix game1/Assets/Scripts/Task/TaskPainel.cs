using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPainel : MonoBehaviour
{
    [SerializeField] int id;
    public static TaskPainel instance;

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

    public int Getid
    {
        get
        {
            return id;
        }
    }
   
}
