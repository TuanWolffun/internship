using UnityEngine;
using UnityEngine.UI;

public class TTTankHealth : MonoBehaviour
{
    public Slider slider;
    public void SetHeath(float health){
        slider.value = health;
    }
}
