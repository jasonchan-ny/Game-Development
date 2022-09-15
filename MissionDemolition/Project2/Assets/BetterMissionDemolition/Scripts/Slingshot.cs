using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S;
    public int projectileAmount = 25;
    public int currentProjectile;

    //fields set in the Unity Inspector pane
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public GameObject prefabProjectile2;
    public GameObject prefabProjectile3;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;

    static public Vector3 LAUNCH_POS
    {
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }

    private void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");  //AHhhhhh
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void OnMouseEnter()
    {
        //Debug.Log("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        //Debug.Log("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (projectileAmount <= 0)
            return;

        //The player has pressed the mouse button while over SlingShot
        aimingMode = true;

        //Instantiate a projectile
        projectile = Instantiate<GameObject>(GetCurrentProjectile());
        //projectile = Instantiate(prefabProjectile) as GameObject;

        //Start it at the launch point
        projectile.transform.position = launchPos;
        //Set it to isKinematic for now
        //projectile.GetComponent < Rigidbody > ().isKinematic = true;

        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (Goal.goalMet == true)
        {
            projectileAmount = 25;
        }

        if (GameEnder.gameEndMet == true)
        {
            GameManager.Instance.ChangeScene();
            GameEnder.gameEndMet = false;
            projectileAmount = 25;
        }

        if (projectileAmount == 0 && Goal.goalMet == false)
        {
            GameManager.Instance.ChangeScene();
        }

        //Changes projectile type
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentProjectile = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentProjectile = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentProjectile = 3;
        }

        //If SlingShot is not in aimingMode, don't run this code
        if (!aimingMode) return; //AAAAHHHH

        //Get the current mouse position in 2D screen coordinate
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;
        //Limit mouseDelta to the radius ot the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            projectileAmount--;
            Debug.Log(projectileAmount);
            //The mouse has been released
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
            MissionDemolition.ShotCounter();
            ProjectileLine.S.poi = projectile;
        }
    }

    GameObject GetCurrentProjectile()
    {
        if (currentProjectile == 1)
            return prefabProjectile;
        else if (currentProjectile == 2)
            return prefabProjectile2;
        else if (currentProjectile == 3)
            return prefabProjectile3;
        else
            return prefabProjectile; 
    }
}
