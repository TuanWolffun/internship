using UnityEngine;

public class TTTankMove : MonoBehaviour
{
    private float moveX;
    private float moveZ;
    public bool destroy;
    private float speed = 4f;
    Rigidbody rb;
    
    void Start(){rb = GetComponent<Rigidbody>();}
    void FixedUpdate(){
        //Debug.Log(transform.forward);
        name = gameObject.tag;
        moveX = Input.GetAxis("Horizontal" + name);
        moveZ = Input.GetAxis("Vertical" + name);
        Turn();
        TankMove();}
    
    void TankMove(){    
        Vector3 movement = transform.forward * moveZ * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
    
    void Turn (){
        float turn = moveX * 45f * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
