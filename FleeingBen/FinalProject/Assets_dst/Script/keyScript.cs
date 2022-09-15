using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
	public GameObject key;

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				key.SetActive(false);
				Door.keyfound = true;
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		
	}
	
}