using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadHero : MonoBehaviour
{
    public Vector3 lastCheckpoint = new Vector3(0, 0, 0);

    private void Start()
    {
        lastCheckpoint = GameManager.Instance.activeCheckpoint;
        transform.position = lastCheckpoint;
    }
}
