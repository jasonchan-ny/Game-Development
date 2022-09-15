using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Target;
    public Collider collision1;
    public AudioSource Walkthrough;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        
            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].SetActive(true);
            }
            collision1.enabled = false;
            Walkthrough.Play();

        }
    }
}