using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObject", menuName = " New Door ")]
public class Door : ScriptableObject
{
    [SerializeField] GameObject doorPrefab;
    [SerializeField] Animator doorAnimator;
    




    public GameObject Prefab
    {
        get
        {
            return doorPrefab;
        }
    }

    public Animator animator
    {
        get
        {
            return animator;
        }
    }
}
