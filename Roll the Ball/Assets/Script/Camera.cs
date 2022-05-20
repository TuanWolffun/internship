using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;         // Distance
    public bool lookAtTarget = false; 
    public float smoothFactor = 0.5f;

    void Start(){
        offset = transform.position - ball.transform.position;
    }
    void  LateUpdate(){
        Vector3 newpos = ball.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newpos, smoothFactor);
        if(lookAtTarget){transform.LookAt(ball);}
    }

}
