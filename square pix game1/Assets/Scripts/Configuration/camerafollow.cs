using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField] Transform Player_body;

    private Vector3 Cameraoffect;

    [Range(0, 1)]
    public float Smoothvelocity;

    private void Start()
    {
        Cameraoffect = transform.position - Player_body.position;
    } 
    private void Update()
    {
        Vector3 nempos = Player_body.position + Cameraoffect;

        transform.position = Vector3.Slerp(transform.position,nempos,Smoothvelocity);
    }
}
