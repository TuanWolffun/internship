using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Tank;
    private Vector3 offset;         // Distance
    public bool lookAtTarget = false; 
    public float smoothFactor = 50f;

    void Start(){
        offset = transform.position - Tank.transform.position;
        //GameObject child = Tank.gameObject.transform.Find("Minicamera").gameObject;
    }
    void  LateUpdate(){
        Vector3 newpos = Tank.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newpos, smoothFactor);
        //float x = 5 * Input.GetAxis ("Mouse X");
        //float y = 5 * -Input.GetAxis ("Mouse Y");
        //transform.Rotate (0, x, 0);
        transform.position = Tank.transform.position - Tank.transform.forward * 10 + new Vector3(0,3,0);
        transform.forward = Tank.transform.forward;
        //if(lookAtTarget){transform.LookAt(Tank.transform);}
    }

}