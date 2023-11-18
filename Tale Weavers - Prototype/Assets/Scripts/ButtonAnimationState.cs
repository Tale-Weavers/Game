using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationState : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { animator.SetTrigger("Activate"); }
    }
}
