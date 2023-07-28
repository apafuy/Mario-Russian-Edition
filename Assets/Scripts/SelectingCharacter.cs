using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character = null;
    public void Click()
    {
        GameManager.Instance.SetCharacter(character);
    }
}
