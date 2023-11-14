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
        Debug.Log("Entra");
        if (other.gameObject.tag == "Player") { animator.SetBool("PlayerIn", true); }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sale");
        if (other.gameObject.tag == "Player") { animator.SetBool("PlayerIn", false); }
    }
}
