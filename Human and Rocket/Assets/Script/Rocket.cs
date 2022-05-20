using UnityEngine;

public class Rocket : MonoBehaviour                 // Bay thẳng ngày càng nhanh
{
    public float startSpeed = 5;
    public float maxSpeed = 20;
    public float accelation = 2;

    public Rigidbody2D myBody;

    public float currentSpeed;
    public bool direction;

    private void Awake()
    {           // Hàm khởi tạo
        myBody = GetComponent<Rigidbody2D>();
        currentSpeed = startSpeed;
    }
    public virtual void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += Time.deltaTime * accelation; // v= a*t
            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
        }
        if (direction == true)
            myBody.velocity = new Vector2(currentSpeed, myBody.velocity.y);
        else
            myBody.velocity = new Vector2(-currentSpeed, myBody.velocity.y);
    }
}
