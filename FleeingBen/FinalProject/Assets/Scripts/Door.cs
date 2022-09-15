using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door_closed, door_opened;
    public AudioSource open, close;
    public bool opened, locked;
    public static bool keyfound;

    void Start()
    {
        keyfound = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (opened == false)
            {
                if (locked == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        door_closed.SetActive(false);
                        door_opened.SetActive(true);
                        StartCoroutine(repeat());
                        opened = true;
                    }
                }
             
            }
        }
    }

    IEnumerator repeat()
    {
        yield return new WaitForSeconds(4.0f);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        close.Play();
    }
    void Update()
    {
        if (keyfound == true)
        {
            locked = false;
        }
    }
}