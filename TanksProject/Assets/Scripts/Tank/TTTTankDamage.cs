using UnityEngine;
using UnityEngine.SceneManagement;

public class TTTTankDamage : MonoBehaviour
{
    public TTTankHealth UIhealth;
    private float maxHealth = 30f;
    private float currentHealth;
    
    void Start(){
        currentHealth = maxHealth + 1;
        UIhealth.SetHeath(maxHealth);
    }

    void Update(){
        UIhealth.SetHeath(currentHealth);
        if(currentHealth <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");}
    }

    public void Ahuhu(float damage){
        Debug.Log("Tank " + gameObject.tag + " - " + damage + " health");
        currentHealth -= damage;
    }
    
}
