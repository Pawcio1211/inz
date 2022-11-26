using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class GoalX : MonoBehaviour
{
    public Transform target;
    public Transform goal;

    float x = 0;
    float y = 0;
    float r = 5;
    double a;

    // Update is called once per frame
    void LateUpdate()
    {
        a = target.rotation.eulerAngles.y - 90.0;
        x = (float)Math.Cos(-a * (Math.PI) / 180 )*r;
        y = (float)Math.Sin(-a * (Math.PI) / 180) * r;
        goal.position = new Vector3(
            x,
            goal.position.y,
            y);
        

    }

}
