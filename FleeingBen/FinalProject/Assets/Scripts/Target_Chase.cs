using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target_Chase : MonoBehaviour
{
    public Rigidbody targetRigid;
    public Transform targetTrans, playTrans;

    public int targSpeed;

    void FixedUpdate()
    {
        targetRigid.velocity = transform.forward * targSpeed * Time.deltaTime;
    }
    void Update()
    {
        targetTrans.LookAt(playTrans);
    }
}