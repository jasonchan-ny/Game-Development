using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterball : MonoBehaviour
{
    public float destroyTime = 4f;

    private void OnTriggerEnter(Collider other)
    {
        //When the trigger is hit by something
        if (other.gameObject.tag == "Ben")
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Invoke("Kill", destroyTime);
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}

