using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManagment : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    private bool IsVisable(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if(plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    private void Update()
    {
        var targetRender = target.GetComponent<Renderer>();
        if (IsVisable(cam, target))
        {
            targetRender.material.SetColor("_Color", Color.red);
        }
        else
        {
            targetRender.material.SetColor("_Color", Color.black);

        }

    }
}
