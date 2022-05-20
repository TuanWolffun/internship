using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    float timeToDestroy = 1;
    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
            Destroy(this.gameObject);
    }
}
