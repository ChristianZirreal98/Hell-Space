using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject outiline;

    private void Update()
    {
        if (!this.gameObject.activeInHierarchy)
        {
            outiline.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            outiline.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        outiline.SetActive(false);
    }
}
