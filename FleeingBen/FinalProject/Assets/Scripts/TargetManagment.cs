using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TargetManagment : MonoBehaviour
{
    public GameObject target ;
    public Camera cam;
    private bool IsVisable(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        var targetRender = target.GetComponent<TargetNavMesh>();
        //var targetRenderColor = target.GetComponent<Renderer>();
        var targetAnimation = target.GetComponent<Animator>();
        var targetNav = target.GetComponent<NavMeshAgent>();

        if (IsVisable(cam, target))
        {
            targetRender.enabled = false;
            targetNav.enabled = false;
            targetAnimation.speed = 0;
        }
        else
        {
            targetRender.enabled = true;
            targetNav.enabled = true;

            targetAnimation.speed = 1;


        }

    }
}
