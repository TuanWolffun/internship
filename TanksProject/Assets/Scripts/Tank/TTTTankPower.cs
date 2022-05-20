using UnityEngine;
using UnityEngine.UI;
public class TTTTankPower : MonoBehaviour
{
    public Slider slider;
    public void SetPower(float pow){
        slider.value = pow;
    }
}
