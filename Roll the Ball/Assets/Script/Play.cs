using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    List<int> Numbers = new List<int>(100);
    Dictionary<int, int> Numbersx = new Dictionary<int, int>(100);
    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void PrintNumbers()
    {
        foreach (int i in Numbers)
            Debug.LogError(i.ToString());
    }
}
