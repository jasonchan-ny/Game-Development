using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float destroyTime = 4f;

/*    private void OnTriggerEnter(Collider other)
    {
        //When the trigger is hit by something
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }*/

    void Start()
    {
        Invoke("Kill", destroyTime);
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
