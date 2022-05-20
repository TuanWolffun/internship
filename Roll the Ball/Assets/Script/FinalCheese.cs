using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FinalCheese : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Collider c;
    internal bool colli;
    private void Start()
    {
        colli = false;
    }

    private void OnCollisionEnter(Collision X){
        if(X.gameObject.CompareTag("Ball")){
            colli = true;
        }
    }
    private void OnCollisionExit(Collision X){
        if(X.gameObject.CompareTag("Ball")){
            colli = false;
        }
    }
    
    private void OnValidate(){
if(!rb){
rb = GetComponent<Rigidbody>();
}
if(!rb){
c = GetComponent<Collider>();
}
    }
}
