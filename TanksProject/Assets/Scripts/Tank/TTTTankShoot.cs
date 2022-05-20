using UnityEngine;

public class TTTTankShoot : MonoBehaviour
{
    private float timeReload;
    private float lazerTime;
    private string mode;

    private int curentShell;           

    private float currentPower;
    private float maxPower = 30f;
    private bool readlyPower;
    private int numShell = 6;

    public GameObject shell;
    public GameObject heatShell;
    public GameObject nameShell;

    public GameObject enemy;
    public ParticleSystem Explored;
    public GameObject Cube;
    private GameObject cube;
    public TTTTankPower pow;
    
    void Start(){
        timeReload = 0;
        currentPower = 0;
        readlyPower = false;
        mode = "One shot";
        curentShell = 1;
    }

    void Update(){
        string name = "Fire" + gameObject.tag;
        string change = "Change" + gameObject.tag;
        string changeMode = "Mode" + gameObject.tag;
        
        if(currentPower >= maxPower && readlyPower){
                currentPower = maxPower;
                Shoot();
        }
        
        else if(Input.GetButtonDown(name) && timeReload <= 0)
                readlyPower = true;
        
        else if(Input.GetButton(name) && readlyPower && timeReload <= 0){
                currentPower += Time.deltaTime * 50;
                if(mode == "Continue")
                    Shoot();
        }
        
        else if (Input.GetButtonUp(name) && readlyPower)
                Shoot();

        pow.SetPower(currentPower);
        if(timeReload > 0)
            timeReload -= Time.deltaTime;

        if(cube){
            cube.gameObject.transform.position = gameObject.transform.position + new Vector3(0,1.3f,0);
            cube.gameObject.transform.forward = gameObject.transform.forward;
            lazerTime -= Time.deltaTime;
        }
        if(lazerTime <= 0){
            Destroy(cube);
            if(curentShell == 3)
                curentShell = 4;
        }

        if(Input.GetButtonDown(change)){
            if(curentShell == numShell)                        
                curentShell = 1;
            else if(curentShell == 2)
                curentShell = 4;
            else
                curentShell ++;    
        }

        if(Input.GetButtonDown(changeMode)){
            if(mode == "One shot")                        
                mode = "Continue";
            else if(mode == "Continue")  
                mode = "Complex";
            else
                mode = "One shot";  
        }

        switch(curentShell){
            case 1:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Normal" + " - " + mode;
                break;
            case 2:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Lazer" + " - " + mode;
                break;
            case 3:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Lazer" + " - " + mode;
                break;
            case 4:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Heat" + " - " + mode;
                break;
            case 5:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Boom" + " - " + mode;
                break;
            case 6:
                nameShell.GetComponent<UnityEngine.UI.Text>().text = "Trap" + " - " + mode;
                break;
        }
    }
    
    void Shoot(){
        if(mode != "Continue")
            readlyPower = false; 
        
        
        if(curentShell == 1)
            Shoot1();
        else if(curentShell == 2){
            Shoot2();
            curentShell = 3;
        }
        else if(curentShell == 3)
            Shoot3();
        else if(curentShell == 4)
            Shoot4();
        else if(curentShell == 5)
            Shoot5();
        else if(curentShell == 6)
            Shoot6();
        
        
        currentPower = 0;    
        if(mode != "Continue"){
            timeReload = 2;  
            gameObject.GetComponent<Rigidbody>().AddForce(-(transform.forward) * 1000f, ForceMode.Impulse);    
        }
        else
            timeReload = 0.2f;
    }

    void Shoot1(){                      // Đạn thường
        if(mode != "Complex"){
            Rigidbody fireeeee = Instantiate(shell.GetComponent<Rigidbody>(), transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
            fireeeee.velocity = (currentPower + 50f) * transform.forward;
        }
        else{
            for(int i = 0; i < 5; i++){
                Rigidbody fireeeee = Instantiate(shell.GetComponent<Rigidbody>(), transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                fireeeee.velocity = (currentPower + 10f) * (transform.forward + new Vector3(transform.forward.z, 0, -transform.forward.x) * (2 - i )/10 );
            } 
        }
    }

    void Shoot2(){                      // Đạn Lazer
        cube = Instantiate(Cube);
        lazerTime = 10;  
    }

    void Shoot3(){                      // Đạn bay thẳng
        if(mode != "Complex"){
            Rigidbody fireeeee = Instantiate(shell.GetComponent<Rigidbody>(), transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
            fireeeee.velocity = (currentPower + 50f) * transform.forward;
            fireeeee.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation ;   
        }
        else{
            for(int i = 0; i < 5; i++){
                Rigidbody fireeeee = Instantiate(shell.GetComponent<Rigidbody>(), transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                fireeeee.velocity = (currentPower + 50f) * (transform.forward + new Vector3(transform.forward.z, 0, -transform.forward.x) * (2 - i ) / 10 );
                fireeeee.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation ;  
            } 
        }
    }
    
    void Shoot4(){                      // Đạn tầm nhiệt
        GameObject fireeeee = Instantiate(heatShell, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
        fireeeee.GetComponent<Rigidbody>().velocity = currentPower * new Vector3(0,1,0);
        if(mode == "Continue")
            fireeeee.GetComponent<Rigidbody>().velocity = 30f * new Vector3(0,1,0);
        fireeeee.GetComponent<TTTHeatShell>().tank = enemy;
        fireeeee.transform.rotation = Quaternion.Euler(-90,0,0);   
    }

    void Shoot5(){                      // Đạn nổ
        if(mode != "Complex"){
            GameObject fireeeee = Instantiate(heatShell, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
            fireeeee.GetComponent<Rigidbody>().velocity = (currentPower + 10f) * (transform.forward + new Vector3(0f, 0.3f, 0f));
            if(mode == "Continue")
                fireeeee.GetComponent<Rigidbody>().velocity = 30f * (transform.forward + new Vector3(0f, 0.3f, 0f));
            fireeeee.GetComponent<TTTHeatShell>().tank = enemy;
            fireeeee.GetComponent<TTTHeatShell>().type = 5;
        }
        else{
            for(int i = 0; i < 5; i++){
                GameObject fireeeee = Instantiate(heatShell, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                fireeeee.GetComponent<Rigidbody>().velocity = (currentPower + 10f) * ((transform.forward + new Vector3(0f, 0.3f, 0f)) + new Vector3(transform.forward.z, 0.3f, -transform.forward.x) * (2 - i )/10 );
                fireeeee.GetComponent<TTTHeatShell>().tank = enemy;
                fireeeee.GetComponent<TTTHeatShell>().type = 5;
            } 
        }
    }

    void Shoot6(){                      // Đặt bom
        if(mode != "Complex"){
            Rigidbody fireeeee = Instantiate(shell.GetComponent<Rigidbody>(), transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
            fireeeee.velocity = (currentPower + 50f) * transform.forward;
            fireeeee.gameObject.GetComponent<TTBoom>().bom = true;
        }
    }
}
