using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheese : MonoBehaviour
{
    public Cheese chesse;
    private Cheese c;
    private Cheese[] C;
    public int numCheese;
    public int currentCheese;
    // Start is called before the first frame update
    void Start()
    {
        numCheese = 4;
        currentCheese = 0;
        C = new Cheese[numCheese];
        for(int i = 0; i < numCheese; i++){
            Spawn(i);
        }
    }

    void Update(){
        int a = 0;
        for(int i = 0; i < numCheese; i++){
            if(C[i].IsCollected == false) {a += 1;}
        }
        //Debug.Log("Đất còn lại: " + a);
        currentCheese = a;
    }

    void Spawn(int i){
        c = Instantiate(chesse);
        Vector3 position = this.transform.position;
        c.transform.position = position + new Vector3(Random.Range(-10f,10f), 2f, Random.Range(-10f,10f));
        C[i] = c;
    }
}
