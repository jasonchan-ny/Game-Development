using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door_closed, door_opened;

    public bool opened = false;
    public bool locked;
    public static bool keyfound;

    void Start()
    {
        keyfound = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
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
                        Debug.Log("Open Please");
                        door_closed.SetActive(false);
                        door_opened.SetActive(true);
                        //open.play();
                        StartCoroutine(repeat());
                        opened = true;
                    }
                }
                
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("hello");

        }
        
           
    }
    IEnumerator repeat()
    {
        yield return new WaitForSeconds(4.0f);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        //close.play();
    }
    void Update()
    {
        if (keyfound == true)
        {
            locked = false;
        }
     
    }
}