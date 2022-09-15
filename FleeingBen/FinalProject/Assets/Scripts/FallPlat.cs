using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallPlat : MonoBehaviour
{
    //public int hints = 3;
    private Scene1FPS player;
    void Start()
    {
        if (gameObject.tag != "EndPlat")
        {
            DecideChildrenPlats();
            //DecideSecondPlat();
        }
    }

    void DecideChildrenPlats()
    {
        Transform firstFallPlat = this.gameObject.transform.parent.GetChild(0);
        Transform secondFallPlat = this.gameObject.transform.parent.GetChild(1);

        if (Random.value > 0.5f)
        {
            firstFallPlat.gameObject.tag = "FallPlat";
            firstFallPlat.gameObject.GetComponent<Collider>().isTrigger = true;

            secondFallPlat.gameObject.tag = "RegPlat";
            secondFallPlat.gameObject.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            firstFallPlat.gameObject.tag = "RegPlat";
            firstFallPlat.gameObject.GetComponent<Collider>().isTrigger = false;

            secondFallPlat.gameObject.tag = "FallPlat";
            secondFallPlat.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Scene1FPS.hints != 0)
        {
            Scene1FPS.hints--;
            if (gameObject.tag == "FallPlat")
            {
                Destroy(this.gameObject);
            }
        }
    }
    // void DecideFirstPlat()
    // {
    //     //for (int i = 0; i < )
    //     Transform firstFallPlat = this.gameObject.transform.parent.GetChild(0);

    //     if (this.gameObject.transform == firstFallPlat)
    //     {
    //         //Debug.Log("firstFallPlat: " + firstFallPlat.name);
    //         if (Random.value > 0.5f)
    //         {
    //             this.gameObject.tag = "FallPlat";
    //         }
    //         else
    //         {
    //             this.gameObject.tag = "RegPlat";
    //             gameObject.GetComponent<Collider>().isTrigger = false;
    //         }
    //         Debug.Log("firstFallPlat: " + firstFallPlat.name + " with tag: " + firstFallPlat.tag);
    //     }
    // }

    // void DecideSecondPlat()
    // {
    //     //second fall plat
    //     //Debug.Log("Not first fall plat" + this.gameObject.name);
    //     Transform firstFallPlat = this.gameObject.transform.parent.GetChild(0);
    //     Transform secondFallPlat = this.gameObject.transform.parent.GetChild(1);
    //     Debug.Log(firstFallPlat.name + " " + secondFallPlat.name);
    //     Debug.Log(firstFallPlat.tag);
    //     if (firstFallPlat.tag == "FallPlat")// && this.gameObject == secondFallPlat)
    //     {
    //         this.gameObject.tag = "RegPlat";
    //         //Debug.Log("Set this gameobject to a regular plat " + this.gameObject.name + " " + this.gameObject.tag);
    //         gameObject.GetComponent<Collider>().isTrigger = false;
    //     }
    //     else if (firstFallPlat.tag == "Untagged")
    //     {
    //         if (Random.value > 0.5f)
    //         {
    //             firstFallPlat.gameObject.tag = "FallPlat";

    //             secondFallPlat.gameObject.tag = "RegPlat";
    //             secondFallPlat.gameObject.GetComponent<Collider>().isTrigger = false;
    //         }
    //         else
    //         {
    //             firstFallPlat.gameObject.tag = "RegPlat";
    //             firstFallPlat.gameObject.GetComponent<Collider>().isTrigger = false;

    //             secondFallPlat.gameObject.tag = "FallPlat";
    //         }
    //     }
    //     else
    //     {
    //         this.gameObject.tag = "FallPlat";
    //     }
    // }
    void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.tag == "FallPlat")
        {
            Destroy(gameObject);
        }
        else if (this.gameObject.tag == "EndPlat")
        {
            SceneManager.LoadScene("Level3");
        }
        // if (collider.gameObject.tag == "Player" && this.gameObject.tag == "FallPlat")
        // {
        //     Destroy(gameObject);
        // }

        //StartCoroutine(Fall(fallTime));
        // foreach (ContactPoint contact in collider.contacts)
        // {
        //Debug.DrawRay(contact.point, contact.normal, Color.white);
        // if (collider.gameObject.tag == "Player")
        // {
        //     StartCoroutine(Fall(fallTime));
        // }
        //}
    }
    //TO DO: Implement random falling tags


    // IEnumerator Fall(float time)
    // {
    //     yield return new WaitForSeconds(time);
    //     Destroy(gameObject);
    // }
}
