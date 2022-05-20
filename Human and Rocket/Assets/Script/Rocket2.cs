using UnityEngine;

public class Rocket2: Rocket{                       // Bay thẳng rồi rượt theo
    protected float distance;
    public GameObject tuan;
    
    public void Start(){
        distance = 0;
    }

    public override void Update(){
        Debug.Log(currentSpeed);
        if(distance < 2)
            GiaiDoan1();

        else if(2 <= distance && distance < 17)
            GiaiDoan2();

        else
            GiaiDoan3();
    }

    protected virtual void GiaiDoan1(){
        myBody.velocity = new Vector2(currentSpeed, myBody.velocity.y); 
        distance += currentSpeed * Time.deltaTime;
    }

    protected virtual void GiaiDoan2(){
        Vector3 tuanPos = tuan.transform.position;
        Vector3 curPos = transform.position;
        
        transform.position = Vector3.MoveTowards(curPos, tuanPos, Time.deltaTime);

        if(tuanPos.x < curPos.x && gameObject.GetComponent<SpriteRenderer>().flipY == false){
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            myBody.velocity = new Vector2(-currentSpeed, myBody.velocity.y); 
        }
        else if(tuanPos.x > curPos.x && gameObject.GetComponent<SpriteRenderer>().flipY == true){
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            myBody.velocity = new Vector2(currentSpeed, myBody.velocity.y); 
        }
        //transform.position = Vector3.MoveTowards(curPos, tuanPos, Time.deltaTime * (currentSpeed));
        distance += currentSpeed * Time.deltaTime;
    }

    protected virtual void GiaiDoan3(){
        Destroy(gameObject);
    }
}