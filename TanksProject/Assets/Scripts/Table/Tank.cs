using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tank")]
public class Tank : ScriptableObject
{
    public new string name;

    public float timeReload;
    public float lazerTime;
    public string mode;

    public int curentShell;           

    public float currentPower;
    public float maxPower = 30f;
    public bool readlyPower;
    public int numShell = 6;

    public GameObject shell;
    public GameObject heatShell;
    public GameObject nameShell;

    public GameObject enemy;
    public ParticleSystem Explored;
    public GameObject Cube;
    public GameObject cube;
    public TTTTankPower pow;
    public TTTankHealth UIhealth;
}
