using System.Collections;
using UnityEngine;

public class Rocket3 : Rocket2                      // Bay 15m rồi nổ
{
    protected bool trans = false;


    protected void OldGiaiDoan1(){base.GiaiDoan1();}
    protected void OldGiaiDoan2(){base.GiaiDoan2();}
    protected void OldGiaiDoan3(){base.GiaiDoan3();}

    protected override void GiaiDoan1(){
        distance = 2;
    }

    protected override void GiaiDoan2(){
        distance += currentSpeed * Time.deltaTime;
        myBody.velocity = new Vector2(currentSpeed, myBody.velocity.y);
    }
    
    protected override void GiaiDoan3(){
        if(trans){
            transform.localScale = new Vector3(2,2,2);
            myBody.velocity = new Vector2(0, 0);}
        Trans();
        StartCoroutine(Booooooommm());
    }

    IEnumerator Booooooommm(){
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    protected void Trans(){
        GetComponent<Animator>().SetBool("Explode", true);
        trans = true;
        CapsuleCollider2D colli = GetComponent<CapsuleCollider2D>();
        colli.offset = new Vector2(-0.05f, 0.05f);
        colli.size = new Vector2(0.3f, 0.3f);
    }
}
