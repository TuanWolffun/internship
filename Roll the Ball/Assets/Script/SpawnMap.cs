using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMap : MonoBehaviour
{
    public GameObject first;
    private GameObject[] maps;
    private int numMaps;
    public int maxnumMaps;
    public FinalCheese final;
    private FinalCheese m;
    // Start is called before the first frame update
    void Start()
    {
        maxnumMaps = 4;
        maps = new GameObject[maxnumMaps + 1];
        m = Instantiate(final);
        maps[0] = Instantiate(first);
        maps[0].GetComponents<Map>()[0].pre = 0;
        numMaps = 1;
        for (int i = 0; i < maxnumMaps + 1; i++)
            Spawn(maps[i]);
    }

    void Update()
    {
        if (!m.colli) return;
        int sum = 0;
        for (int i = 0; i < maxnumMaps + 1; i++)
            if (maps[i].GetComponent<SpawnCheese>().currentCheese == 0)
                sum++;
        if (sum == maxnumMaps + 1)
        {
            Destroy(m.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

    void Spawn(GameObject c)
    {
        if (numMaps == maxnumMaps + 1) { return; }
        GameObject current = Instantiate(c);
        Vector3 position = c.transform.position;
        int ran = Random.Range(-1, 2);
        if (ran == -1)
        {
            if (c.GetComponents<Map>()[0].pre == -1)
            {
                current.transform.position = position + new Vector3(0, Random.Range(-1f, 1f), Random.Range(22f, 25f));
                current.GetComponents<Map>()[0].pre = 0;
            }
            else
            {
                current.transform.position = position + new Vector3(-Random.Range(22f, 25f), Random.Range(-1f, 1f), 0);
                current.GetComponents<Map>()[0].pre = 1;
            }
        }
        else if (ran == 1)
        {
            if (c.GetComponents<Map>()[0].pre == 1)
            {
                current.transform.position = position + new Vector3(0, Random.Range(-1f, 1f), Random.Range(22f, 25f));
                current.GetComponents<Map>()[0].pre = 0;
            }
            else
            {
                current.transform.position = position + new Vector3(Random.Range(22f, 25f), Random.Range(-1f, 1f), 0);
                current.GetComponents<Map>()[0].pre = -1;
            }
        }
        else
        {
            current.transform.position = position + new Vector3(0, Random.Range(-1f, 1f), Random.Range(22f, 25f));
            current.GetComponents<Map>()[0].pre = 0;
        }
        maps[numMaps] = current;
        numMaps++;
    }
}
