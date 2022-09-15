using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;
    public GameObject fireball;
    public Transform firePoint;
    public float fireSpeed = 10f;
    public float timeToFire = 1.3f;
    float originalTime;
    //public AudioClip shootingAudio;

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToFire;
    }

    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            enemy.LookAt(target.transform);
        }
        
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToFire -= Time.deltaTime;

            if(timeToFire < 0)
            {
                firePlayer();
                timeToFire = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }
    }

    private void firePlayer()
    {
        GameObject currentFireBall = Instantiate(fireball, firePoint.position, firePoint.rotation);
        Rigidbody rig = currentFireBall.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * fireSpeed, ForceMode.VelocityChange);

        AudioManager.Instance.PlayShootingAudio();
    }
}
