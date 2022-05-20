using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    [SerializeField]
    private GameObject rocket; 

    private GameObject currentrocket;

    private float size;
    private float currentSpeed;
    private int side;
    private int timeplay;
    void Start()
    {

        StartCoroutine(SpawnRocket());
    }
    
    IEnumerator SpawnRocket(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,3));
            timeplay++;
            side = Random.Range(0,2);
            currentrocket = Instantiate(rocket);
            if(side == 0){
                currentrocket.GetComponent<Rocket>().direction = true;
                currentrocket.transform.position = new Vector3(-10f, Random.Range(-4f,2f), 0f);
                currentrocket.GetComponent<SpriteRenderer>().flipY = true;
                currentrocket.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            else{
                currentrocket.GetComponent<Rocket>().direction = false;
                currentrocket.transform.position = new Vector3(10f, Random.Range(-4f,2f), 0f);
                currentrocket.transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
            }
        }
    }
}
