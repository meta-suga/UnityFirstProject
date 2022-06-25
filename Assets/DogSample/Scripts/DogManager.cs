using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        Debug.Log("スタート");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetFloat("MoveSpeed", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetFloat("MoveSpeed", 0.0f);
        }
    }

    public void hitLog()
    {
        Debug.Log("hit!!");
    }
}