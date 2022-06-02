using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quantum;

public class QuantumDeadScreen : QuantumCallbacks
{
    string text;
    int numPlayer;
    private int[,] playerAsset;
    [SerializeField]
    private ParticleSystem m_ExplosionAnimation;

    private void Start()
    {
        QuantumEvent.Subscribe<EventDeath>(this, handle1);
        QuantumEvent.Subscribe<EventAlive>(this, handle2);
        QuantumEvent.Subscribe<EventStart>(this, handle3);
        QuantumEvent.Subscribe<EventUpdateHealth>(this, handle4);
        QuantumEvent.Subscribe<EventUpdatePoint>(this, handle5);
        QuantumEvent.Subscribe<EventReset>(this, handle6);
        QuantumEvent.Subscribe<EventShellExplored>(this, handle7);
        //gameObject.SetActive(false);
        text = gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text;
        numPlayer = 0;
        playerAsset = new int[10,3];
    }
    private void handle1(EventDeath a)
    {
        //gameObject.SetActive(true);
    }
    private void handle2(EventAlive a)
    {
        //gameObject.SetActive(false);
    }
    private void handle3(EventStart a)
    {
        Debug.Log("Tham gia");
        var index = a.index;
        var health = a.health;
        playerAsset[numPlayer, 0] = index;
        playerAsset[numPlayer, 1] = 0;
        playerAsset[numPlayer, 2] = health;
        numPlayer++;
        view();
    }
    private void handle4(EventUpdateHealth a)
    {
        for(int i = 0; i < numPlayer; i++)
        {
            if( playerAsset[i, 0] == a.index)
            {
                playerAsset[i, 2] -= 1;
                break;
            }
        }
        view();
    }
    private void handle5(EventUpdatePoint a)
    {
        for (int i = 0; i < numPlayer; i++)
        {
            if (playerAsset[i, 0] == a.index)
            {
                playerAsset[i, 1] += 1;
                break;
            }
        }
        view();
    }
    private void handle6(EventReset a)
    {
        for (int i = 0; i < numPlayer; i++)
        {
            if (playerAsset[i, 0] == a.index)
            {
                playerAsset[i, 2] = a.health;
                break;
            }
        }
        view();
    }
    private void view()
    {
        //Debug.Log(text);
        //Debug.Log("Now: " + gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text);
        //Debug.Log(numPlayer);
        gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "==================\n\n";
        for (int i = 0; i < numPlayer; i++)
        {
            gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text += "Player: " + playerAsset[i, 0].ToString() 
                                                                                        + "\nPoint: " + playerAsset[i, 1].ToString() 
                                                                                        + "\nHealth: " + playerAsset[i, 2].ToString() 
                                                                                        + "\n\n==================\n";
        }
        //Debug.Log(text);
        //Debug.Log("Then: " + gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text);
    }
    private void handle7(EventShellExplored a)
    {
        
        var x = Instantiate(m_ExplosionAnimation);
        x.transform.position = a.exploredPosition.ToUnityVector3();
        //Debug.Log("Vi tri no: "+ x.transform.position);
        x.Play();
        //ParticleSystem.MainModule mainModule = m_ExplosionAnimation.main;
        //Destroy(m_ExplosionAnimation.gameObject, mainModule.duration);
    }
}
