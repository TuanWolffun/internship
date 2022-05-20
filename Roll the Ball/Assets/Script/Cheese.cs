using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Collider c;
    public bool IsCollected;
    void Start()
    {
        IsCollected = false;
        rb = GetComponent<Rigidbody>();
        c = GetComponent<BoxCollider>();
        //Debug.Log(c.isTrigger);
    }

    void OnCollisionEnter(Collision X){
        //Debug.Log("aaaaaaaaaaaaaa");
    }
}
