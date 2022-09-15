using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject fireball;
    public Transform firePoint;
    public float fireSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            firePlayer();
        }
    }

    private void firePlayer()
    {
        GameObject currentFireBall = Instantiate(fireball, firePoint.position, firePoint.rotation);
        Rigidbody rig = currentFireBall.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * fireSpeed, ForceMode.VelocityChange);
    }
}