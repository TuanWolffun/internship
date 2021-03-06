using UnityEngine;

public class TTTLazer : MonoBehaviour
{
    private LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit)){
            if(hit.collider)
                lr.SetPosition(1, hit.point);
        }
        else
            lr.SetPosition(1, transform.forward*5000);
    }
}
