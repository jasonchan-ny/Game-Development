using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightScript : MonoBehaviour
{
	public GameObject flashlight_ground, flashlight_player;
    public AudioSource pickup;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                flashlight_ground.SetActive(false);
                flashlight_player.SetActive(true);
                pickup.Play();
            }

        }
    }

  

	
}