using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName = null;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.resetDeath();
            goNextLevel();
        }
    }
    
    // Update is called once per frame
    public void goNextLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
