using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb = null;
    private bool jumpKey = false;
    private bool kickKey = false;
    [SerializeField] private float jumpForce = 100;
    [SerializeField] private float speed = 2;
    [SerializeField] private KeyCode jumpButton = KeyCode.Space;
    [SerializeField] private KeyCode kickButton = KeyCode.Mouse0;
    private Animator mainHeroAnimator = null;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainHeroAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            mainHeroAnimator.SetBool("isJump", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            jumpKey = true;
        }

        if (Input.GetKeyDown(kickButton))
        {
            kickKey = true;
        }

        if (Input.GetKeyUp(kickButton))
        {
            mainHeroAnimator.SetBool("isKicking", false);
        }
    }

    private void FixedUpdate()
    {
        if (!mainHeroAnimator.GetBool("isDie"))
        {
            if (jumpKey && isGrounded)
            {
                mainHeroAnimator.SetBool("isRun", false);
                mainHeroAnimator.SetBool("isJump", true);
                rb.AddForce(Vector2.up * jumpForce);
                jumpKey = false;
                isGrounded = false;
            }

            if (kickKey && !mainHeroAnimator.GetBool("isJump") && !mainHeroAnimator.GetBool("isRun"))
            {
                mainHeroAnimator.SetBool("isRun", false);
                mainHeroAnimator.SetBool("isKicking", true);
                kickKey = false;
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            if (rb.velocity.x != 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * MathF.Sign(Input.GetAxis("Horizontal"));
                transform.localScale = scale;
                if (!mainHeroAnimator.GetBool("isJump"))
                {
                    mainHeroAnimator.SetBool("isRun", true);
                }
            
            }
            else
            {
                mainHeroAnimator.SetBool("isRun", false);
            }
        } else if (kickKey)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
        
    }
}
