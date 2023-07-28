using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Checkpoint : MonoBehaviour
{
    public Vector3 checkpoinPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        checkpoinPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SetActiveCheckpoint(checkpoinPosition);
        }
    }
}
