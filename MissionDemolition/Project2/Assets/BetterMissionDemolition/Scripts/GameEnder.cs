using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    static public bool gameEndMet = false;

    private void OnTriggerEnter(Collider other)
    {
        //When the trigger is hit by something
        //Check to see if it's a Projectile
        if (other.gameObject.tag == "Projectile")
        {
            //If so, set goalMet to true
            GameEnder.gameEndMet = true;

            //Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}