using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxAnimatorStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerBehaviour>().Hidden = true;
            animator.SetBool("PlayerIn", true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerBehaviour>().Hidden = false;
            animator.SetBool("PlayerIn", false); 
        }
    }
}
