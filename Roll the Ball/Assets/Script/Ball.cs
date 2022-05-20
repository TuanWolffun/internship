using UnityEngine;

public class Ball : MonoBehaviour

{
    private float moveX;
    private float moveZ;
    Rigidbody rb;
    public Vector3 jump;
    public bool isGrounded, onair;
    public bool destroy;
    private float speed = 5f;
    public int total;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        total = 0;
    }
    void Update()
    {
        BallMove();
        if (transform.localPosition.y < -10f)
            transform.localPosition = new Vector3(0f, 3f, 0f);
    }

    void BallMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * 3f, ForceMode.Impulse);
            isGrounded = false;
            onair = true;
        }
        transform.position += new Vector3(moveX, 0f, moveZ) * Time.deltaTime * speed;
    }
    void OnCollisionEnter(Collision X)
    {
        if (X.gameObject.CompareTag("Ground"))
             onair = false;
        if (X.gameObject.CompareTag("Cheese"))
        {
            var Cheese = X.gameObject.GetComponent<Cheese>();
            if (Cheese.IsCollected)
                return;
            Cheese.IsCollected = true;
            Debug.LogError("OnCollectChesse With ID: " + X.gameObject.GetInstanceID().ToString());
            Destroy(X.gameObject);
            transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            speed += 0.5f;
        }
    }
    void OnCollisionStay()
    {
        if(!onair)
            isGrounded = true;
    }
}

// Chuyen chiu nhiem move 1 game object
public class MoveComponent: MonoBehaviour
{

}