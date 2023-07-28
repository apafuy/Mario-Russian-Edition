using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance.deathCount == 0)
        {
            GameManager.Instance.SetActiveCheckpoint(transform.position);
            GameManager.Instance.Death();
        }

        Instantiate(GameManager.Instance.character);
    }
}
