using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class RestartWhenDie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator mainHeroAnimator = collision.GetComponent<Animator>();
            mainHeroAnimator.SetBool("isRun", false);
            mainHeroAnimator.SetBool("isJump", false);
            mainHeroAnimator.SetBool("isKicking", false);
            mainHeroAnimator.SetBool("isDie", true);
        }
    }
}
