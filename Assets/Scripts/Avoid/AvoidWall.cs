using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWall : Seek
{
    public float avoidDistance;
    public float lookAhead;
    public override void Awake()
    {
        base.Awake();
        target = new GameObject();
    }
    public override Steering GetSteering()
    {
        Vector3 position = transform.position + transform.forward * avoidDistance;

        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, lookAhead))
        {
            position = hit.point + hit.normal * avoidDistance;
        }
        target.transform.position = position;
        Steering steering = base.GetSteering();

        return steering;
    }
}
