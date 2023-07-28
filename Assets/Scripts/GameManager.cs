using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Vector3 activeCheckpoint;
    public GameObject character;
    public int deathCount = 0;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetActiveCheckpoint(Vector3 checkpoint)
    {
        activeCheckpoint = checkpoint;
    }

    public void SetCharacter(GameObject value)
    {
        character = value;
    }
    
    public void Death()
    {
        deathCount++;
    }

    public void resetDeath()
    {
        deathCount = 0;
    }
}
