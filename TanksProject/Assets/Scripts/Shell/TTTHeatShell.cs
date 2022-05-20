using UnityEngine;
using System.Collections;

public class TTTHeatShell : MonoBehaviour
{
    private bool run = true;
    public bool flag = false;

    public int type = 0;
    private bool boom = false;

    private int a = 0;

    public ParticleSystem Explored;
    public GameObject tank;
    Vector3 tankpos;
    Rigidbody rb;

    void Start() { rb = GetComponent<Rigidbody>(); }
    void Update()
    {
        if (type == 5)
        {
            if (Vector3.Distance(transform.position, tank.transform.position) <= 5f && !boom)
            {
                boom = true;
                ParticleSystem explored = Instantiate(Explored, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
                explored.Play();
                tank.gameObject.GetComponent<TTTTankDamage>().Ahuhu(10f);
                Destroy(gameObject);
            }
        }

        else
        {
            if (run && rb.velocity.magnitude <= 0.5)
            {
                run = false;
                rb.isKinematic = true;
                tankpos = tank.transform.position;
            }

            if (!run)
            {
                transform.forward = Vector3.MoveTowards(transform.position, tankpos, Time.deltaTime * 50f);
                transform.position = Vector3.MoveTowards(transform.position, tankpos, Time.deltaTime * 50f);
            }
        }
    }

    void OnTriggerExit() { flag = true; }
    void OnTriggerEnter(Collider tank)
    {
        if (flag && a == 1)
        {
            ParticleSystem explored = Instantiate(Explored, transform.position + new Vector3(0f, 1.3f, 0f), transform.rotation);
            explored.Play();
            if (tank.gameObject.CompareTag("Green") || tank.gameObject.CompareTag("Red"))
                tank.gameObject.GetComponent<TTTTankDamage>().Ahuhu(10f);
            Destroy(gameObject);
        }
        a++;
    }
}
