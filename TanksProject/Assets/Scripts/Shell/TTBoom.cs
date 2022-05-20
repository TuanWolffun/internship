using UnityEngine;

public class TTBoom : MonoBehaviour
{
    public bool flag = false;
    public bool bom = false;
    private int a = 0;
    public ParticleSystem Explored;
    private float v;
    void Start(){a = 0;}
    void LateUpdate()
    {
         v = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }

    void OnCollisionExit(){flag=true;}
    void OnCollisionEnter(Collision tank){
        if(flag && a >= 1 && !bom){
            if(!tank.gameObject.CompareTag("Shell")){
                ParticleSystem explored = Instantiate(Explored, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                explored.Play();
                if(tank.gameObject.CompareTag("Green") || tank.gameObject.CompareTag("Red")){
                    tank.gameObject.GetComponent<TTTTankDamage>().Ahuhu(v * 0.2f);
                    tank.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward) * 500f, ForceMode.Impulse);                  
                }
                Destroy(gameObject);
            }
        }
        else if(flag && a >= 1 && bom){
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            if(tank.gameObject.CompareTag("Green") || tank.gameObject.CompareTag("Red")){
                ParticleSystem explored = Instantiate(Explored, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                explored.Play();
                tank.gameObject.GetComponent<TTTTankDamage>().Ahuhu(20f);
                tank.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward) * 500f, ForceMode.Impulse); 
                Destroy(gameObject);                 
            }
        }
        a++;    
    }
}
